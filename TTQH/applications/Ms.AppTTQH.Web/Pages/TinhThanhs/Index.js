$(function () {
    var l = abp.localization.getResource('AppTTQH');

    var createModal = new abp.ModalManager(abp.appPath + 'TinhThanhs/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'TinhThanhs/EditModal');

    var dataTable = $('#TinhThanhTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(tinhThanhModule.controllers.tinhThanh.getList),
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
                                        return l('TinhThanhDeletionConfirmationMessage',
                                            data.record.tenTinhThanh);
                                    },
                                    action: function (data) {
                                        tinhThanhModule.controllers.tinhThanh
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
                    title: l('MaTinhThanh'),
                    data: "maTinhThanh"
                },
                {
                    title: l('TenTinhThanh'),
                    data: "tenTinhThanh",
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

    $('#NewTinhThanhButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

});