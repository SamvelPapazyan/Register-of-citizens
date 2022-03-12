Ext.application({
    requires: ['Ext.container.Viewport'],
    name: 'NewTestApp',
    appFolder: 'app',
    controllers: ['Citizens'],
    
    launch: function() {
        Ext.create('Ext.container.Viewport', {
            
            layout: {type: 'hbox', align: 'stretch'},
            items: [{
                xtype: 'citizenform'
            },{
                xtype: 'citizenlist'
            }]
        });
    }
});