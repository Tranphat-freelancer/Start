$(function () {
    var l = abp.localization.getResource('Main');
    var createModal = new abp.ModalManager(abp.appPath + 'MainApps/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'MainApps/EditModal');

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
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    confirmMessage: function (data) {
                                        return l('MainAppDeletionConfirmationMessage',
                                            data.record.content );
                                    },
                                    action: function (data) {
                                        main.controllers.mainApp
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }

                            ]
                    }
                },
                {
                    title: l('Id'),
                    data: "id"
                },
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

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewMainAppButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
