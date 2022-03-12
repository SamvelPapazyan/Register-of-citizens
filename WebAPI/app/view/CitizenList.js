Ext.define('NewTestApp.view.CitizenList' ,{
    extend: 'Ext.grid.Panel',
    alias: 'widget.citizenlist',
 
    title: '<div style="text-align:center;font-size:28px;font-style:italic;color: #0c2ef1;">Список граждан</div>',
    store: 'CitizenStore',    
    width: 690,   
     
    initComponent: function() {
        this.columns = [{
            text: '<div style="text-align:center;font-size:21px;color: #0c2ef1;line-height:30px;">Фамилия</div>',
            flex: 1,
            sortable: true,
            dataIndex: 'lastName',
            field: {
                xtype: 'textfield'
            }
        }, {
            text: '<div style="text-align:center;font-size:21px;color: #0c2ef1;line-height:30px;">Имя</div>',
            flex: 1,
            sortable: true,
            dataIndex: 'firstName',
            field: {
                xtype: 'textfield'
            }
        }, {
            text: '<div style="text-align:center;font-size:21px;color: #0c2ef1;line-height:30px;">Отчество</div>',
            flex: 1,
            sortable: true,
            dataIndex: 'middleName',
            field: {
                xtype: 'textfield'
            }
        }, {
            text: '<div style="text-align:center;font-size:21px;color: #0c2ef1;line-height:30px;">Дата рождения</div>',
            flex: 1,
            sortable: true,
            dataIndex: 'birthday',
            field: {
                xtype: 'datecolumn',
                format: 'd.m.Y'
            }
        }];
         
        this.callParent(arguments);
    }
});