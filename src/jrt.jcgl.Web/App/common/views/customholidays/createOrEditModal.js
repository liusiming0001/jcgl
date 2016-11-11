(function () {
    appModule.controller('common.views.customholidays.createOrEditModal', [
        '$scope', '$modalInstance', 'abp.services.app.customHolidays', 'customHolidayId',
        function ($scope, $modalInstance, customHolidaysService, customHolidayId) {
            var vm = this;

            vm.saving = false;
            vm.holiday = null;
            vm.save = function () {
                vm.saving = true;
                customHolidaysService.createCustomHoliday(vm.holiday.toLocaleDateString()).success(function () {
                    abp.notify.info(app.localize('SavedSuccessfully'));
                    $modalInstance.close();
                }).finally(function () {
                    vm.saving = false;
                });
            };

            vm.cancel = function () {
                $modalInstance.dismiss();
            };

            //customHolidaysService.createInit().success(function (result) {
            //    vm.holiday = result;
            //    //var myDate = new Date();
            //    //vm.holiday.holiday = myDate.toLocaleDateString();
            //});
        }
    ]);
})();