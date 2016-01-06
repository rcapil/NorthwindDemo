(function () {
    $('.supplier-name').click(function () {
        var supplierObj = $(this).data('supplier');

        $('.modal-title').html(supplierObj.CompanyName);
        $('dd.contact-name').html(supplierObj.ContactName + ', <i>' + supplierObj.ContactTitle + '</i>');
        $('dd.address').html(supplierObj.Address);
        $('dd.city').html(supplierObj.City);
        $('dd.postal-code').html(supplierObj.PostalCode);
        $('dd.region').html(supplierObj.Region);
        $('dd.country').html(supplierObj.Country);
        $('dd.phone').html(supplierObj.Phone);
        $('dd.fax').html(supplierObj.Fax);
    });
}());