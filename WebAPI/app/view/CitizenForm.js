Ext.define('NewTestApp.view.CitizenForm', {
    extend: 'Ext.form.Panel',
    alias: 'widget.citizenform',
 
    title: '<div style="text-align:center;font-size:28px;font-style:italic;color: #0c2ef1;">Поля для ввода условий поиска</div>',  
    autoShow: true,

    bodyPadding: '5 5',
    width: 675,

    fieldDefaults: {
        xtype: 'form',
        columnWidth:0.5,
        labelAlign: 'top',
        anchor: '100%',
    },
 
    initComponent: function() {
        this.items = [{
            fieldLabel: 'Фамилия',            
            name: 'lastName',
            allowBlank: false,
            xtype: 'textfield'            
        },{
            fieldLabel: 'Имя',            
            name: 'firstName',
            allowBlank: false,
            xtype: 'textfield'            
        },{
            fieldLabel: 'Отчество',
            name: 'middleName',
            xtype: 'textfield'            
        }, {
            fieldLabel: 'Начало периода даты рождения',
            allowBlank: false,            
            name: 'startDate',
            xtype: 'datefield',
            format: 'd.m.Y'            
        }, {
            fieldLabel: 'Окончание периода даты рождения',            
            allowBlank: false,
            name: 'finishDate',
            xtype: 'datefield',
            format: 'd.m.Y'            
        }];

        this.dockedItems=[{
            xtype:'toolbar',
            docked: 'top',

            items: [{
                scale: 'medium',
                itemId: 'search',
                text: '<div style="text-align:center;font-size:20px;color: #0c2ef1;">Поиск</div>',
                iconCls: 'icon-user',
                action: 'search'
            }, {
                scale: 'medium',
                itemId: 'print',
                text: '<div style="text-align:center;font-size:20px;color: #0c2ef1;">Печать</div>',
                iconCls: 'icon-user',                
                action: 'print'
            }, {
                scale: 'medium',
                itemId: 'change',
                text: '<div style="text-align:center;font-size:20px;color: #0c2ef1;">Изменить</div>',
                iconCls: 'icon-add',
                action: 'change'
            }, {
                scale: 'medium',
                itemId: 'add',
                text: '<div style="text-align:center;font-size:20px;color: #0c2ef1;">Добавить</div>',
                iconCls: 'icon-add',
                action: 'add'
            }, {
                scale: 'medium',
                itemId: 'delete',
                text: '<div style="text-align:center;font-size:20px;color: #0c2ef1;">Удалить</div>',
                iconCls: 'icon-delete',
                action: 'delete'
            }, {
                scale: 'medium',
                itemId: 'exit',
                text: '<div style="text-align:center;font-size:20px;color: #0c2ef1;">Выход</div>',
                iconCls: 'icon-delete',
                action: 'exit'
                }]
            }];    
        this.callParent(arguments);
    }
});