(function () {

    appModule.controller('common.views.rawmaterials.index', [
        '$scope', '$modal', '$templateCache', 'abp.services.app.rawMaterial', 'uiGridConstants',
        function ($scope, $modal, $templateCache, rawMaterialService, uiGridConstants) {
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.loading = false;

            vm.permissions = {
                create: abp.auth.hasPermission('Pages.ProductionManagers.RawMaterialInfoManagers.Create'),
                edit: abp.auth.hasPermission('Pages.ProductionManagers.RawMaterialInfoManagers.Edit'),
                'delete': abp.auth.hasPermission('Pages.ProductionManagers.RawMaterialInfoManagers.Delete')
            };

            vm.rawmaterialGridOptions = {
                enableHorizontalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                enableVerticalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
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
                            '      <li><a ng-if="grid.appScope.permissions.edit" ng-click="grid.appScope.editRawMaterial(row.entity)">' + app.localize('Edit') + '</a></li>' +
                            '      <li><a ng-if="!row.entity.isStatic && grid.appScope.permissions.delete" ng-click="grid.appScope.deleteRawMaterial(row.entity)">' + app.localize('Delete') + '</a></li>' +
                            '    </ul>' +
                            '  </div>' +
                            '</div>'
                    },
                    {
                        name: app.localize('RawMaterial.Name'),
                        field: 'name',
                        minWidth: 120,
                    },
                    {
                        name: app.localize('RawMaterial.BatchNumber'),
                        field: 'batchNumber',
                        minWidth: 120,
                    },
                    {
                        name: app.localize('RawMaterial.Producer'),
                        field: 'producer',
                        minWidth: 120,
                    },
                    {
                        name: app.localize('RawMaterial.Manufacturer'),
                        field: 'manufacturer',
                        minWidth: 120,
                    },
                    {
                        name: app.localize('RawMaterial.Supplier'),
                        field: 'supplier',
                        minWidth: 120,
                    },
                    {
                        name: app.localize('RawMaterial.Level'),
                        field: 'level',
                        minWidth: 120,
                    },
                    {
                        name: app.localize('RawMaterial.Specifications'),
                        field: 'specifications',
                        minWidth: 120,
                    },
                    {
                        name: app.localize('RawMaterial.Units'),
                        field: 'units',
                        cellTemplate:
                            '<div class=\"ui-grid-cell-contents\">' +
                            '  <span ng-show="row.entity.units==0" class="label label-success">' + app.localize('Enums.jrt.jcgl.RawMaterials.UnitsType.KG') + '</span>' +
                            '  <span ng-show="row.entity.units==1" class="label label-warning">' + app.localize('Enums.jrt.jcgl.RawMaterials.UnitsType.T') + '</span>' +
                            '</div>',
                        minWidth: 120,
                    }
                ],
                data: []
            };

            if (!vm.permissions.edit && !vm.permissions.delete) {
                vm.rawmaterialGridOptions.columnDefs.shift();
            }

            vm.getRawMaterials = function () {
                vm.loading = true;
                rawMaterialService.getRawMaterialList({}).success(function (data) {
                    vm.rawmaterialGridOptions.data = data.items;
                    console.log(data.items);
                }).finally(function () {
                    vm.loading = false;
                });
            };

            vm.editRawMaterial = function (rawmaterial) {
                openCreateOrEditRawMaterialModal(rawmaterial.id);
            };

            vm.deleteRawMaterial = function (rawmaterial) {
                abp.message.confirm(
                    app.localize('RawMaterialDeleteWarningMessage', rawmaterial.name),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            rawMaterialService.deleteRawMaterial(
                                 rawmaterial.id
                            ).success(function () {
                                vm.getRawMaterials();
                                abp.notify.success(app.localize('SuccessfullyDeleted'));
                            });
                        }
                    }
                );
            };

            vm.createRawMaterial = function () {
                openCreateOrEditRawMaterialModal(null);
            };

            function openCreateOrEditRawMaterialModal(rawmaterialId) {
                var modalInstance = $modal.open({
                    templateUrl: '~/App/common/views/rawmaterials/createOrEditModal.cshtml',
                    controller: 'common.views.rawmaterials.createOrEditModal as vm',
                    backdrop: 'static',
                    resolve: {
                        rawmaterialId: function () {
                            return rawmaterialId;
                        }
                    }
                });

                modalInstance.result.then(function (result) {
                    vm.getRawMaterials();
                });
            }

            vm.getRawMaterials();
        }
    ]);
})();