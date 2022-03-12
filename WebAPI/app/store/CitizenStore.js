Ext.define('NewTestApp.store.CitizenStore', {
    extend: 'Ext.data.Store',
    model: 'NewTestApp.model.Citizen',
    autoLoad: false,
    storeId: 'CitizenStore',
    proxy: {
        type: 'ajax',
        url: 'https://localhost:44369/api/SearchCitizen/GetAllCitizens',
        reader: {
            type: 'json',
            root: 'citizens',
            successProperty: 'success'
        }
    }
});