
//declare Variables
var ProjectID = '', taskHours = 0, ProjectID = 0;
var ProjectTitle = "", ProjectDescription = ""

$(document).ready(function () {

    $("#txtHours").keypress(function (e) {
        //if the letter is not digit then display error and don't type anything
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            //display error message
            $("#spnHours").html("Please enter digits only");
            return false;
        }
        else {
            $("#spnHours").html("");
        }
    });

});

    $(document).delegate("#btnsaveTask", "click", function () {

        taskTitle = $('#txtTaskTitle').val().trim();
        if (taskTitle == "") {
            $("#spntaskTile").html("Please enter task title");
            setTimeout(function () { $("#spntaskTile").html(""); }, 3000);
            return false;
        } else {
            $("#spntaskTile").html("");
        }

    ProjectID= $('#ddlProject').val();
        if (ProjectID == "0") {
        $("#spnProject").html("Please select project");
        setTimeout(function () { $("#spnProject").html(""); }, 3000);
        return false;
        }
        else {
         $("#spnProject").html("");
        } 
        taskHours = $('#txtHours').val();

        if (taskHours == "") {
            $("#spnHours").html("Please enter hours");
            setTimeout(function () { $("#spnHours").html(""); }, 3000);
            return false;
        }
        else {
            $("#spnHours").html("");
        } 

    $.ajax({
        url: "/Projects.ashx",
        type: "Post",
        dataType: "json",
        data: {
            type: 1,
            taskTitle: taskTitle,
            ProjectID: ProjectID,
            taskHours: taskHours
        },
        success: function (res) {
            res.RetVal = 1
            {
                $("#successText").html("Added Successfully");
                $("#ddlProject").val(0);
                $("#txtTaskTitle").val("");
                $("#txtHours").val("");
            }
        },
        error: function (res, err) {
            console.log(res);
            console.log(err);
        }
    });

    });

$(document).delegate("#btnSaveProject", "click", function () {

    ProjectTitle = $('#txtproject').val();
    if (ProjectTitle == "") {
        $("#spnTile").html("Please enter title").trim();
        setTimeout(function () { $("#spnTile").html(""); }, 3000);
        return false;
    } else {
        $("#spnTile").html("");
    }

    ProjectDescription = $('#txtdescription').val().trim();
    if (ProjectDescription == "") {
        $("#spndescription").html("Please enter description ");
        setTimeout(function () { $("#spndescription").html(""); }, 3000);
        return false;
    }
    else {
        $("#spndescription").html("");
    }
    $.ajax({
        url: "/Projects.ashx",
        type: "Post",
        dataType: "json",
        data: {
            type: 2,
            ProjectTitle: ProjectTitle,
            ProjectDescription: ProjectDescription,
        },
        success: function (res) {
            res.RetVal = 1
            {
                $("#successText").html("Project Added Successfully");
                $("#txtproject").val("");
                $("#txtdescription").val("");
                setTimeout(function () {
                    window.location.href = "/Projects/AddProjectTask";
                }, 3000);
            }
        },
        error: function (res, err) {
            console.log(res);
            console.log(err);
        }
    });

});

