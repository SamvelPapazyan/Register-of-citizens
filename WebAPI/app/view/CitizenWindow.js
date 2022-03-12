Ext.define('NewTestApp.view.CitizenWindow', {
    extend: 'Ext.window.Window',
    alias: 'widget.citizenwindow',
 
    title: '<div style="text-align:center;font-size:28px;font-style:italic;color: #0c2ef1;">Анкета гражданина</div>',
    layout: 'form',    
    autoShow: false,

    bodyPadding: '5 5',
    width: 850,
    
    initComponent: function () {
        this.items = [{
            xtype: 'form',
            fieldDefaults: {
                width: 800,
                columnWidth: 0.5,
                labelAlign: 'top',
                anchor: '100%',
            },
            items: [{                    
                    fieldLabel: 'Фамилия',                   
                    name: 'lastName',
                    allowBlank: false,
                    xtype: 'textfield'                    
                }, {                    
                    fieldLabel: 'Имя',                    
                    name: 'firstName',
                    allowBlank: false,
                    xtype: 'textfield'                    
                }, {                    
                    fieldLabel: 'Отчество',
                    name: 'middleName',
                    xtype: 'textfield'                    
                }, {                   
                    fieldLabel: 'Дата рождения',                    
                    allowBlank: false,
                    name: 'birthday',
                    xtype: 'datefield',
                    format: 'd.m.Y'                    
                }]
        }];

        this.buttons = [{
                    text: '<div style="text-align:center;font-size:20px;color: #0c2ef1;">Изменить</div>',
                    scale: 'large',
                    scope: this,
                    action: 'change'
                }, {
                    text: '<div style="text-align:center;font-size:20px;color: #0c2ef1;">Добавить</div>',
                    scale: 'large',
                    scope: this,
                    action: 'exit'
        }];

        this.callParent(arguments);
    }
});