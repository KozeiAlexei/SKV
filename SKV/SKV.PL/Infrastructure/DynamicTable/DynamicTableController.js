angular.module('SKV').controller('DynamicTableController', ['$scope', function ($scope) {
    var self = this;

    //Инициализация контроллера
    self.Initialize = function () {

        //Параметры таблицы
        self.TableParams = {

            //Класс таблицы
            TableClass: 'table table-striped table-bordered table-hover dataTable no-footer',

            //Класс строки поиска
            FilterRowClass: null,

            //Класс ячейки таблицы
            FieldValueClass: 'editable-text',

            //Класс поля поиска
            FilterFieldClass: 'form-control',

            //Подсказка при поиске
            FilterPlaceholder: 'Поиск...',

            //Класс редактируемого поля
            EditableFieldClass: 'form-control',

            DisableColumnClass: 'disable_column',

            TableManagmentPanelClass: 'table_managment_panel',

            EnableEditing: true,

            EnableFiltering: true,

            EnablePagination: true,

            EnableDynamicCellTyping: false,

            EnableManagmentPanel: true,

            PageSizes: [5, 10, 15]
        };

        self.PrivateParams = {
            $$PageCount: 0,
            $$CurrentRow: null,
            $$CurrentPage: 1,
            $$CurrentPageSize: self.TableParams.PageSizes[1]
        }

        //Данные для выпадающих списков
        self.DropdownData = [];

        //Строки таблицы
        self.Rows = [];

        self.CurrentRows = [];

        self.CurrentPageRows = [];

        //Действия с таблицей
        self.Actions = [];

        //Столбы таблицы
        self.Columns = [];

        self.Filters = {};

        self.SaveChangesFunc = null;

        self.ShowHideContentFunc = null;

        //Панель управления таблицой
        self.TableManagmentPanel = null;
    };

    $scope.TableManagment = {

        //Настройка контроллера
        Columns: function (source) {
            self.Columns = source;
        },

        //Загрузка данных в таблицу
        LoadData: function (data) {
            delete self.Rows;

            if (self.PrivateParams.$$CurrentRow!= null) {
                self.PrivateParams.$$CurrentRow.Params.IsEditing = false;
                self.PrivateParams.$$CurrentRow = null;
            }

            self.Rows = new Array(data.length);
            angular.forEach(data, function (item, i) {
                self.Rows[i] = self.CreateRow(item);
            });

            self.CurrentRows = angular.copy(self.Rows);

            self.ReCalcPages();
            self.GoToPage(1);
        },

        LoadDropdownData: function(data) {
            self.DropdownData = data;
        },

        //Показать контент
        ShowHideContent: function (row) {
            if (self.PrivateParams.$$CurrentRow != row) {
                if (self.PrivateParams.$$CurrentRow == null)
                    self.PrivateParams.$$CurrentRow = row;
                else {
                    self.PrivateParams.$$CurrentRow.Params.ContentVisible = false;
                    self.PrivateParams.$$CurrentRow = row;
                }
                self.PrivateParams.$$CurrentRow.Params.ContentVisible = !self.PrivateParams.$$CurrentRow.Params.ContentVisible;

                if(self.ShowHideContentFunc != null)
                    self.ShowHideContentFunc(row);
            } else {
                self.PrivateParams.$$CurrentRow.Params.ContentVisible = !self.PrivateParams.$$CurrentRow.Params.ContentVisible;
                self.PrivateParams.$$CurrentRow = null;
            }
            
        },

        SetShowHideContentFunction: function(func) {
            self.ShowHideContentFunc = func;
        },

        DeleteLastRow : function() {
            var last = self.Rows.pop(); self.CurrentRows.pop();
            if (self.PrivateParams.$$CurrentRow == last) {
                self.PrivateParams.$$CurrentRow.Params.IsEditing = false;
                self.PrivateParams.$$CurrentRow = null;
            }
            self.ReCalcPages();
            self.GoToPage(1);
        },

        //Задать код управляющей панели таблицы
        SetTableManagmentPanelCode: function (html) {
            self.TableManagmentPanel = html;
        },

        SetDropdownData: function (dropdownData) {
            self.DropdownData = dropdownData;
        },

        SetActions: function (actions) {
            self.Actions = actions;
        },

        Editable: function(editing) {
            self.TableParams.EnableEditing = editing;
        },

        Filterable: function (filtering) {
            self.TableParams.EnableFiltering = filtering;
        },

        Paginable: function (pagination) {
            self.TableParams.EnablePagination = pagination;
        },

        EnableDynamicCellTyping: function(dynamic_typing) {
            self.TableParams.EnableDynamicCellTyping = dynamic_typing;
        },

        EnableManagmentPanel: function (mpanel) {
            self.TableParams.EnableManagmentPanel = mpanel;
        },

        AddFilter: function (name, val) {
            self.Filters[name] = val;
        },

        RemoveFilter: function (name) {
            delete self.Filters[name];
        },

        SetCurrentRow: function(row) {
            self.PrivateParams.$$CurrentRow = row;
        },

        AddRow: function (data) {
            var row = self.CreateRow(data);

            self.Rows.push(row);
            self.CurrentRows.push(row);

            self.ReCalcPages();

            self.GoToPage(self.PrivateParams.$$CurrentPage);
        },

        SetSaveChangesFunc: function (func) {
            self.SaveChangesFunc = func;
        },

        GetCurrentRow: function() {
            return self.PrivateParams.$$CurrentRow;
        },

        GetRows: function () {
            return self.Rows;
        },

        GetColumns: function() {
            return self.Columns;
        },

        SetValidationErrors: function(errors) {
            self.ValidationErrors = errors;
        },

        LockUnlockColumn: function (columnName, mode) {
            angular.forEach(self.Columns, function (item) {
                if (item.Name == columnName)
                    item.IsEditable = mode;
            });
        },

        ToDefault: function () {
            if (self.PrivateParams.$$CurrentRow != null)
                $scope.TableManagment.ShowHideContent(self.PrivateParams.$$CurrentRow);

            self.ReCalcPages();
            self.GoToPage(1);
        },

        PageSize: function (size) {
            self.SetPageSize(size);
        }
    }

    self.GoToPage = function (page) {
        if (self.PrivateParams.$$CurrentRow == null) {
            self.PrivateParams.$$CurrentPage = page;

            var start = self.PrivateParams.$$CurrentPageSize * (self.PrivateParams.$$CurrentPage - 1);
            var end = self.PrivateParams.$$CurrentPageSize * self.PrivateParams.$$CurrentPage;

            self.CurrentPageRows = self.CurrentRows.slice(start, end);
        }
    }

    self.ReCalcPages = function () {
        self.PrivateParams.$$PageCount = Math.ceil(self.CurrentRows.length / self.PrivateParams.$$CurrentPageSize);
    }

    self.SetPageSize = function (size) {
        self.PrivateParams.$$CurrentPageSize = size;
        self.ReCalcPages();
        self.GoToPage(1);
    }

    self.CreateRow = function (item) {
        var row = {
            Params: {
                IsEditing: false,
                ContentClass: null,
                DataRowClass: null,
                ContentVisible: false
            },
            RenderContent: function (row) {
                return item.RenderContent(row);
            }
        };
        angular.forEach(item.Data, function (value, key) {
            if (Object.prototype.toString.call(value) == '[object Object]') {
                angular.forEach(value, function (v_value, v_key) {
                    row[key + '.' + v_key] = v_value;
                });
            }
            row[key] = value;
        });

        return row;
    }

    self.EditRow = function (row) {
        if (self.PrivateParams.$$CurrentRow == null) {
            self.PrivateParams.$$CurrentRow = row;
            self.PrivateParams.$$CurrentRow.Params.IsEditing = true;
        } 
    }

    self.SaveChanges = function (row) {
        if (self.PrivateParams.$$CurrentRow != null && self.PrivateParams.$$CurrentRow != row) {
            self.SaveChangesFunc(self.PrivateParams.$$CurrentRow, function () {
                self.PrivateParams.$$CurrentRow.Params.IsEditing = false;
                self.PrivateParams.$$CurrentRow = null;
            });
        }
    };

    self.ClearCurrentRow = function () {
        if (self.PrivateParams.$$CurrentRow != null) {
            self.PrivateParams.$$CurrentRow.Params.IsEditing = false;
            self.PrivateParams.$$CurrentRow = null;
        }
    }

    self.PrevPage = function () {
        if (self.PrivateParams.$$CurrentPage > 1) 
            self.GoToPage(self.PrivateParams.$$CurrentPage - 1);
          
    }

    self.NextPage = function () {
        if (self.PrivateParams.$$CurrentPage < self.PrivateParams.$$PageCount) 
            self.GoToPage(self.PrivateParams.$$CurrentPage + 1);
           
    }
    
    self.GetPageRange = function () {
        var range = []; 

        var cur = self.PrivateParams.$$CurrentPage;
        if (cur - 2 >= 1 && cur + 2 <= self.PrivateParams.$$PageCount) {
            range.push(cur - 2); range.push(cur - 1);
            range.push(cur);
            range.push(cur + 1); range.push(cur + 2);
        } else {
            if (cur - 2 >= 1)
                range.push(cur - 2);
            if (cur - 1 >= 1)
                range.push(cur - 1);

            range.push(cur);

            if (cur + 1 <= self.PrivateParams.$$PageCount)
                range.push(cur + 1);
            if (cur + 2 <= self.PrivateParams.$$PageCount)
                range.push(cur + 2);
        }

        return range;
    }

    self.RowFilter = function (row) {
        var result = true;
        angular.forEach(self.Filters, function (value, key) {
            if (row[key] != null && row[key].toString().indexOf(value) >= 0)
                result &= true;
            else
                result &= false;
        });

        return result;
    }

    self.Filtrate = function () {
        self.CurrentRows.length = 0;
        angular.forEach(self.Rows, function (item) {
            if (self.RowFilter(item))
                self.CurrentRows.push(item);
        });
    }

    self.GetCurrentPageRows = function () {
        self.Filtrate();

        self.ReCalcPages();
        self.GoToPage(self.PrivateParams.$$CurrentPage);

        return self.CurrentPageRows;
    }

    self.Initialize();
}]);
