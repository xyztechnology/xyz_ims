var j = jQuery.noConflict();
function AddClickEvents() {
    //remove the event first
    j('#addCategoryItem').unbind('click');
    j("#addCategoryItem").click(function () {
        j.ajax({
            url: this.href,
            cache: false,
            success: function (html) {
                j("#div_Categories").append(html);
                AddClickEvents();
            },
            error: function (html) {
                alert(html);
            }
        });
        return false;
    });

    //remove the event first
    j('.addSubcategoryItem').unbind('click');
    j(".addSubcategoryItem").click(handleNewItemClick);

    //remove the event first
    j('.addProductItem').unbind('click');
    j(".addProductItem").click(handleNewItemClick);

    function handleNewItemClick() {
        
            var parent = this.parentElement;
            var formData = {
                id: parent.id
            };
            j.ajax({
                type: "POST",
                url: this.href,
                data: JSON.stringify(formData),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    j(parent).append(data);
                    AddClickEvents();
                },
                error: function (data) {
                    alert(data);
                }
            });
            return false;
    }
}