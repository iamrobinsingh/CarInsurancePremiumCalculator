
var CarInsuranceViewModel = function (data, baseUri)
{
    var self = this;
    self.carBrands = data.CarBrands.map((item) => { return { id: item.BrandId, text: item.Name, variant: item.Variants } });

    $("#car-brands").prepend('<option selected></option>').select2({
        placeholder: "Select Brand",
        allowClear: true,
        data: self.carBrands,
        width:"resolve"
    })
    $("#car-variants").prepend('<option selected></option>').select2({
        placeholder: "Select Variant",
        data: [],
        width: "resolve",
        allowClear: true
    })
    $('#car-brands').on('select2:select', function (e)
    {
        var data = e.params.data;
        var variant = data.variant.map((item) => { return { id: item.VariantId, text: item.VariantName } });
        $('#car-variants').val(null).empty();
        $("#car-variants").prepend('<option selected></option>').select2({
            placeholder: "Select Variant",
            data: variant,
            width: "resolve",
            allowClear: true
        })
    });

    self.calculatePremiumBtn = document.querySelector("#calcBtn");

    self.calculatePremiumAndIDV = function ()
    {
        var obj = {};
        obj.PhoneNumber = $("#phoneNumber").val();
        obj.PersonName = $("#name").val();
        obj.Email = $("#email").val();
        obj.CarBrandId = $("#car-brands").val();
        obj.CarVariantId = $("#car-variants").val();
        obj.RegisteredYear = $("#registeredYear").val()
        obj.RegisteredCity = $("#city").val();
        obj.RegistrationNumber = $("#registrationNumber").val();

        if (obj.PhoneNumber > 0 && obj.PersonName && obj.PersonName.trim() != "" && obj.Email && obj.Email.trim() != "" && obj.CarBrandId > 0
            && obj.CarVariantId > 0 && obj.RegisteredYear && obj.RegisteredYear.trim() != "" && obj.RegisteredCity && obj.RegistrationNumber) {
            $.ajax({
                type: "POST",
                url: baseUri + "CarInsurance/CalculateIDVandPremium",
                data: obj
            }).done(
                function (retData) {
                    if (retData && retData != null) {
                        var currencyFormatting = new Intl.NumberFormat('en-IN');
                        var idvDisplayElement = document.querySelector('#idv');
                        var premiumDisplayElement = document.querySelector('#premium');
                        var registrationNumber = document.querySelector("#selectedRegistrationNumber");
                        idvDisplayElement.innerText = currencyFormatting.format(retData.idv);
                        premiumDisplayElement.innerHTML = currencyFormatting.format(retData.premium);
                        registrationNumber.innerHTML = retData.registrationNumber
                        $("#displayIdvAndPremiumModal").modal('show');
                    }
                    else {
                        alert("There was some error in calculating the Premium.")
                    }
                }
            ).fail(
                function () {
                    alert("There was some error in calculating the Premium.")
                }
            );
        }
        else
        {
            alert("Please enter all the details.")
        }
    }
}

