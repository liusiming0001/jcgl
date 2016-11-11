(function () {

    appModule.controller('common.views.customholidays.index', [
        '$scope', '$modal', '$templateCache', 'abp.services.app.customHolidays', 'uiGridConstants',
        function ($scope, $modal, $templateCache, customHolidaysService, uiGridConstants) {
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.loading = false;

            vm.permissions = {
                create: abp.auth.hasPermission('Pages.Administration.CustomHolidays.Create'),
                'delete': abp.auth.hasPermission('Pages.Administration.CustomHolidays.Delete')
            };

            var requestParams = {
                skipCount: 0,
                maxResultCount: app.consts.grid.defaultPageSize,
                sorting: null
            };

            vm.customHolidayGridOptions = {
                enableHorizontalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                enableVerticalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                paginationPageSizes: app.consts.grid.defaultPageSizes,
                paginationPageSize: app.consts.grid.defaultPageSize,
                useExternalPagination: true,
                useExternalSorting: true,
                appScopeProvider: vm,
                columnDefs: [
                    {
                        name: app.localize('Actions'),
                        enableSorting: false,
                        width: 120,
                        cellTemplate:
                            '<div class=\"ui-grid-cell-contents\">' +
                            '  <div class="btn-group dropdown" dropdown="">' +
                            '    <button class="btn btn-xs btn-primary blue" dropdown-toggle="" aria-haspopup="true" aria-expanded="false"><i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span></button>' +
                            '    <ul class="dropdown-menu">' +
                            '      <li><a ng-if="!row.entity.isStatic && grid.appScope.permissions.delete" ng-click="grid.appScope.deletecustomHoliday(row.entity)">' + app.localize('Delete') + '</a></li>' +
                            '    </ul>' +
                            '  </div>' +
                            '</div>'
                    },
                    {
                        name: app.localize('Holiday'),
                        field: 'holiday',
                        cellFilter: 'momentFormat: \'YYYY-MM-DD\''
                    }
                ],
                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                    $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                        if (!sortColumns.length || !sortColumns[0].field) {
                            requestParams.sorting = null;
                        } else {
                            requestParams.sorting = sortColumns[0].field + ' ' + sortColumns[0].sort.direction;
                        }

                        vm.getcustomHolidays();
                    });
                    gridApi.pagination.on.paginationChanged($scope, function (pageNumber, pageSize) {
                        requestParams.skipCount = (pageNumber - 1) * pageSize;
                        requestParams.maxResultCount = pageSize;

                        vm.getcustomHolidays();
                    });
                },
                data: []
            };

            if (!vm.permissions.edit && !vm.permissions.delete) {
                vm.customHolidayGridOptions.columnDefs.shift();
            }

            vm.getcustomHolidays = function () {
                vm.loading = true;
                customHolidaysService.getCusomHolidayList({
                    skipCount: requestParams.skipCount,
                    maxResultCount: requestParams.maxResultCount,
                    sorting: requestParams.sorting
                }).success(function (data) {
                    vm.customHolidayGridOptions.data = data.items;
                }).finally(function () {
                    vm.loading = false;
                });
            };

            vm.deletecustomHoliday = function (customHoliday) {
                abp.message.confirm(
                    app.localize('CustomHolidayDeleteWarningMessage'),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            customHolidaysService.deleteCustomHoliday(
                                customHoliday.id
                            ).success(function () {
                                vm.getcustomHolidays();
                                abp.notify.success(app.localize('SuccessfullyDeleted'));
                            });
                        }
                    }
                );
            };

            vm.createcustomHoliday = function () {
                openCreateOrEditcustomHolidayModal(null);
            };

            function openCreateOrEditcustomHolidayModal(customHolidayId) {
                var modalInstance = $modal.open({
                    templateUrl: '~/App/common/views/customholidays/createOrEditModal.cshtml',
                    controller: 'common.views.customholidays.createOrEditModal as vm',
                    backdrop: 'static',
                    resolve: {
                        customHolidayId: function () {
                            return customHolidayId;
                        }
                    }
                });

                modalInstance.result.then(function (result) {
                    vm.getcustomHolidays();
                });
            }

            vm.getcustomHolidays();
        }
    ]);
})();