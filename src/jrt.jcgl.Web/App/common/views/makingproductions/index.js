(function () {

    appModule.controller('common.views.makingproductions.index', [
        '$scope', '$modal', 'uiGridConstants', 'abp.services.app.productionPlans', 'abp.services.app.commonLookup', 'lookupModal', '$q',
        function ($scope, $modal, uiGridConstants, productionPlansService, commonLookupService, lookupModal, $q) {
            var vm = this;
            vm.value = null;
            vm.startdate = null;
            vm.types = [];
            vm.type_selcet = null;
            vm.organzations = [];
            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });
            vm.createProductionPlan = function () {

            }

            vm.addorganzation = function () {
                lookupModal.open({

                    title: app.localize('SelectAUser'),
                    serviceMethod: commonLookupService.findSCX,

                    canSelect: function (item) {
                        return $q(function (resolve, reject) {
                            resolve(item);
                        });
                    },

                    callback: function (selectedItem) {
                        vm.organzations.push(selectedItem);
                    }
                });
            }

            vm.init = function () {
                productionPlansService.getSchedulingTypes().success(function (result) {
                    vm.types = result.items;
                    console.log(result);
                });
               
            }

            vm.init();
        }]);
})();