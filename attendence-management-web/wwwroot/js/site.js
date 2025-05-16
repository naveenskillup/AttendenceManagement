$(function () {
    $('.name').inputmask({ regex: "[a-zA-Z\\s]{0,25}"});
    $('.full-name').inputmask({ regex: "[a-zA-Z\\s]{0,50}" });
    $('.mobile-number').inputmask({ regex: "[0-9\\s]{0,10}" });
	$('.datepicker').datepicker({
		format: 'dd-mm-yyyy',  // Set the format you want
		autoclose: true,
		todayHighlight: true,
		startDate: new Date()
	}).on('changeDate', function (e) {
		$(this).closest('.input-group').find('.datepicker-input').val(e.format());
    });
    $(".datepicker-input").inputmask("99/99/9999", {
        placeholder: "DD/MM/YYYY",
        clearIncomplete: true
    });
    $("#submit-student-form").validate({
        rules: {
            LastName: {
                required: true,
                minlength: 3,
                maxlength: 50
            },
            Class: {
                required: true
            },
            Address: {
                maxlength: 200
            },
            FatherMobileNumber: {
                required: true,
                digits: true,
                minlength: 10,
                maxlength: 10
            },
            FatherName: {
                required: true,
                minlength: 3,
                maxlength: 50
            }
        },
        messages: {
            LastName: {
                required: "LastName is required.",
                minlegnth: "LastName must be 3 chars",
                maxlegnth: "Maximum allowed characters are 50"
            },
            Class: {
                required: "Class is required"
            },
            Address: {
                maxlength: "maximum allowed length is 200 chars"
            },
            FatherMobileNumber: {
                required: "MobileNumber number is required",
                digits: "Allows only digits",
                minlength: "Must be 10 digits",
                maxlength: "Must be 10 digits"
            },
            FatherName: {
                required: "FatherName is required.",
                minlegnth: "LastName must be 3 chars",
                maxlegnth: "Maximum allowed characters are 50"
            }
        },
        errorPlacement: function (error, element) {
            var name = element.attr("name");
            $("[data-valmsg-for='" + name + "']").html(error);
        },
        submitHandler: function (form) {
            form.submit();
        }
    });

    $("#submit-teacher-form").validate({
        rules: {
            LastName: {
                required: true,
                minlength: 3,
                maxlength: 50
            },
            Address: {
                maxlength: 200
            },
            MobileNumber: {
                maxlength: 10
            },
            Salary: {
                required: true,
                range: [50, 250]
            },
            Subject: {
                required: true
            }
        },
        messages: {
            LastName: {
                required: "LastName is required.",
                minlegnth: "LastName must be 3 chars",
                maxlegnth: "Maximum allowed characters are 50"
            },
            Address: {
                maxlength: "maximum allowed length is 200 chars"
            },
            MobileNumber: {
                maxlength: "must be 10 digits"
            },
            Salary: {
                required: "Salary is required",
                range: "Salary must be between 50k and 250k"
            },
            Subject:{
                required: "Subject is required"
            }
        },
        errorPlacement: function (error, element) {
            var name = element.attr("name");
            $("[data-valmsg-for='" + name + "']").html(error);
        },
        submitHandler: function (form) {
            form.submit();
        }
    });

    $("#submit-class-form").validate({
        rules: {
            Class: {
                required: true,
                range: [1, 10]
            },
            Limit: {
                required: true,
                range: [25, 100]
            }
        },
        messages: {
            Class: {
                required: "Class name is required.",
                range: "Class must be between 1 and 10"
            },
            Limit: {
                required: "Limit is required.",
                range: "Limit must be between 25 and 100"
            }
        },
        errorPlacement: function (error, element) {
            var name = element.attr("name");
            $("[data-valmsg-for='" + name + "']").html(error);
        },
        submitHandler: function (form) {
            form.submit(); 
        }
    });

    $("#refresh-students-attendence").on("click", function () {
        debugger;
        const baseUrl = window.location.origin;
        $.ajax({
            url: `${baseUrl}/Attendence/StudentsAttendence`,  // ✅ Controller action URL
            type: 'GET',
            data: { classId: 7, date: '', openWithPresent: false }, // ✅ Query params
            success: function (response) {
                $("#students-attendence").html(response);
            },
            error: function (xhr, status, error) {
                alert(error);
                alert(xhr);
                alert(status);
            }
        });
    });

});