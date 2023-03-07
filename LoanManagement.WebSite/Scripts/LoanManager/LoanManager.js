 
$(document).ready(function () {
    $(".ui-datepicker").datepicker({
        dateFormat: "dd-mm-yy",
        changemonth: true,
        changeyear: true
    });
});
$(function () {  
    
    $("#btnSave").click(function () {  
        //alert("");  
        var customerData = {};  
        customerData.customerName = $("#CustomerName").val();
        customerData.customerTypeId = $("#CustomerTypeId").val();
        var stringCustomerData = JSON.stringify(customerData);
        $.ajax({  
            type: "POST",  
            url: applicationURL+"AddCustomerAjax",
            data: stringCustomerData,
            dataType: "json",  
            contentType: "application/json; charset=utf-8",  
            success: function (data) {  
                alert("Data has been added successfully: " + data.Message);
                
            },  
            error: function (err) {  
                alert("Error while inserting data: " + err);
            }  
        });  
        return false;  
    });  

    
});  