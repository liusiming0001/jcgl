(function () {

    appModule.controller('common.views.schedulingsdays.index', [
        '$scope', '$modal', 'uiGridConstants', 'abp.services.app.schedulings',
        function ($scope, $modal, uiGridConstants, schedulingsService) {
            var vm = this;
            vm.date = null;
            vm.daywork = [];
            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });
            vm.getschedulings = function () {
                console.log(vm.date);
                schedulingsService.getSchedulingInfoFormDate({
                    workDate: vm.date 
                }).success(function (result) {
                    vm.daywork = result;
                    console.log(result);
                });
            }

            vm.getschedulings();
        }]);
})();