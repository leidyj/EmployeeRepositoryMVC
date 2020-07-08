$(document).ready(function () {

    CargarGrid();

});

function OnlyNumbers(e) {
    var key = window.event ? e.which : e.keyCode;
    if (key < 48 || key > 57) {
        e.preventDefault();
    }
}

function GetEmployees() {
    var Id = $("#txtId").val();
    if (Id === '') {
        $.ajax({
            type: "POST",
            url: "/Home/GetAllEmployees",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: 0,
            success: function (data) {
                if (data.Response)
                    LLenarGrid(data.Result);
                else
                    swal(data.Message);
            }
        });
    }
    else if (Number.isInteger(parseInt(Id)))
    {
        var IdEmployee = parseInt(Id);
        $.ajax({
            type: "GET",
            url: "/Home/GetEmployeeById",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                Id: IdEmployee
            },
            success: function (data) {
                if (data.Response)
                    LLenarGrid(data.Result);
                else
                    swal(data.Message);
            }
        });
    }
}

function LLenarGrid(dataSource) {

    var grid = $("#gridEmployees").data("kendoGrid");
    var dataSource = new kendo.data.DataSource({
        type: "json",
        data: dataSource,
        pageSize: 10,
        cache: false,
        async: false
    });
    grid.setDataSource(dataSource);
};

function CargarGrid(data) {
    if (data !== null) {
        $.noConflict();
        $("#gridEmployees").kendoGrid({

            columns: [{
                    title: "Id",
                    field: "id",
                    width: "130px"
                },
                {
                    title: "Name",
                    field: "name",
                    width: "150px"
                },
                {
                    title: "Contract Type Name",
                    field: "contractTypeName",
                    width: "150px"
                },
                {
                    title: "Role ID",
                    field: "roleId",
                    width: "130px"
                },
                {
                    title: "Role Name",
                    field: "roleName",
                    width: "200px"
                },
                {
                    title: "Role Description",
                    field: "roleDescription",
                    width: "200px"
                },
                {
                    title: "Hourly Salary",
                    field: "hourlySalary",
                    width: "150px"
                },
                {
                    title: "Monthly Salary",
                    field: "monthlySalary",
                    width: "150px"
                },
                {
                    title: "Annual Salary",
                    field: "annualSalary",
                    width: "200px"
                }],

            editable: true,
            sortable: true,
            scrollable: true,
            reorderable: true,
            resizable: true,
            columnMenu: true,
            filterable: {
                mode: "row"
            },

            pageable: {
                refresh: false,
                buttonCount: 5,
                filterable: {
                    mode: "row"
                },
                messages: {
                    display: "Mostrando de {0} a {1} de {2} registros",
                    empty: "No hay registros",
                    next: "Página Siguente",
                    last: "Página Final",
                    first: "Página De Inicio",
                    previous: "Página Anterior"
                }
            },

        });

        GridCreada = true;


    } else {
        $("#gridEmployees").addClass('hide');
        ////if (MostrarMensajeDeGridVacio !== 1)
        ////    $("#gridEmployees").data("kendoGrid").dataSource.data([]);
    }

};