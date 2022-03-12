Ext.define('NewTestApp.controller.Citizens', {
    extend: 'Ext.app.Controller',
 
    views: ['CitizenList', 'CitizenForm', 'CitizenWindow'],
    stores: ['CitizenStore'],
    models: ['Citizen'],
    init: function() {
        this.control({
            'citizenform button[action=search]': {
                click: this.searchCitizen
            },
            'citizenform button[action=print]': {
                click: this.printReport
            },
            'citizenform button[action=change]': {
                click: this.updateCitizen
            },
            'citizenform button[action=add]': {
                click: this.addCitizen
            },
            'citizenwindow button[action=exit]': {
                click: this.addFromWindow
            },
            'citizenwindow button[action=change]': {
                click: this.updateFromWindow
            },
            'citizenform button[action=delete]': {
                click: this.deleteCitizen
            },
            'citizenform button[action=exit]': {
                click: this.exitForm
            }            
        });
    },

    searchCitizen: function (button) {
        var viewport = button.up('viewport');
        var form = viewport.down('form');
        values = form.getValues();
        var grid = Ext.widget('citizenlist');

        Ext.Ajax.request({
            url: 'https://localhost:44369/api/SearchCitizen/SearchCitizens',
            params: values,

            success: function (response) {                
                var result = Ext.decode(response.responseText);
                var store = grid.getStore();
                store.loadData(result)
            },

            failure: function (response) {
                var result = JSON.parse(response.responseText);
                Ext.Msg.alert('Ошибка', result.Message);
            }
        });
    },

    printReport: function (button) {
        var viewport = button.up('viewport');
        var form = viewport.down('form');
        values = form.getValues();

        Ext.Ajax.request({
            url: 'https://localhost:44369/api/Reports/PrintReport',
            params: values,

            success: function (response) {
                //var result = JSON.parse(response.responseText);
                Ext.Msg.alert('Уведомление', "Отчёт должен появиться в папке назначения");
            },

            failure: function (response) {
                var result = JSON.parse(response.responseText);
                Ext.Msg.alert('Ошибка', result.Message);
            }
        });
    },

    updateCitizen: function (button) {
        var viewport = button.up('viewport');
        var grid = viewport.down('gridpanel');
        var record = grid.getSelectionModel().getSelection()[0];

        var view = Ext.widget('citizenwindow');
        view.down('form').loadRecord(record);
        view.show();
    },

    addCitizen: function (button) {
        var view = Ext.widget('citizenwindow');
        view.show()
    },

    addFromWindow: function (button) {
        var win = button.up('window'),
            form = win.down('form'),
            values = form.getValues();
            
        Ext.Ajax.request({
            url: 'https://localhost:44369/api/Citizens/AddCitizen',
            params: values,

            success: function (response) {                
                Ext.Msg.alert('Уведомление', 'Данные успешно добавлены');
            },

            failure: function (response) {
                var result = JSON.parse(response.responseText);
                Ext.Msg.alert('Ошибка', result.Message);
            }
        });

        var store = Ext.widget('citizenlist').getStore();
        store.reload();
    },

    updateFromWindow: function (button) {
        var win = button.up('window'),
            form = win.down('form'),
            values = form.getValues();
        id = form.getRecord().get('id');
        values.id = id;

        Ext.Ajax.request({
            url: 'https://localhost:44369/api/Citizens/UpdateCitizen',
            params: values,

            success: function (response) {
                Ext.Msg.alert('Уведомление', 'Данные успешно изменены');
            },

            failure: function (response) {
                var result = JSON.parse(response.responseText);
                Ext.Msg.alert('Ошибка', result.Message);
            }
        });

        var store = Ext.widget('citizenlist').getStore();
        store.load();
    },

    deleteCitizen: function (button) {
        var viewport = button.up('viewport');
        var grid = viewport.down('gridpanel');
        var record = grid.getSelectionModel().getSelection()[0];

        var view = Ext.widget('citizenwindow');
        var form = view.down('form').loadRecord(record);
        var values = form.getValues();

        Ext.Ajax.request({
            url: 'https://localhost:44369/api/Citizens/DeleteCitizen',
            params: values,
            success: function (response) {
                Ext.Msg.alert('Уведомление', 'Данные гражданина успешно удалены');               
            },

            failure: function (response) {
                var result = JSON.parse(response.responseText);
                Ext.Msg.alert('Ошибка', result.Message);
            }
        });
        
        var store = grid.getStore();
        store.reload();
    },

    exitForm: function (button) {       
        var viewport = button.up('viewport');
        viewport.removeAll();            
    }   
});