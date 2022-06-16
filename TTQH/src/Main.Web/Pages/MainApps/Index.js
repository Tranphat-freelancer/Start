$(function () {
    var l = abp.localization.getResource('Main');

    var dataTable = $('#MainAppTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(main.controllers.mainApp.getList),
            columnDefs: [
                {
                    title: l('Content'),
                    data: "content"
                },
                {
                    title: l('CreationTime'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );
    //Dynamic Javascript Client Proxies

    //Call Modal
    var createModal = new abp.ModalManager(abp.appPath + 'MainApps/CreateModal');

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewMainAppButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

}); 
