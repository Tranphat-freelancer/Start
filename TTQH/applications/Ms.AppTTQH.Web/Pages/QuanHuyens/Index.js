$(function () {
    var l = abp.localization.getResource('AppTTQH');

    var createModal = new abp.ModalManager(abp.appPath + 'QuanHuyens/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'QuanHuyens/EditModal');

    var dataTable = $('#QuanHuyenTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(quanHuyenModule.controllers.quanHuyen.getList),
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
                                        return l('QuanHuyenDeletionConfirmationMessage',
                                            data.record.tenQuanHuyen);
                                    },
                                    action: function (data) {
                                        quanHuyenModule.controllers.quanHuyen
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
                    title: l('MaQuanHuyen'),
                    data: "maQuanHuyen"
                },
                {
                    title: l('TenQuanHuyen'),
                    data: "tenQuanHuyen",
                },
                {
                    title: l('IdTinhThanh'),
                    data: "idTinhThanh",
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

    $('#NewQuanHuyenButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
    tinhThanhModule.controllers.tinhThanh.getList({
        maxResultCount: 10
    }).then(function (result) {
        console.log(result.items);
    });

});
