

// function alert 
window.Alert = (message, bool) => {

    alert(message);

    if (bool == true)
        location.reload(bool);
    
  
    ///window.location.href in blazor
}

//function disaable buttons modal

window.Disable = () => {
  
    $(".modal-footer button").addClass("disabled");
    $(".modal-header button").addClass("disabled");
   
}


// function datatable

window.Document = () => {

    $("#datatable").DataTable().destroy();
   
    $("#datatable").DataTable({
        orderCellsTop: true,
        lengthMenu: [6],
        lengthChange: false,
        searching: false,
        
    });
   
}
