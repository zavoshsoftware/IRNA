
$(document).ready(() => {
    $('.swiper-slide').filter(function () { //use filter on all .categories
        var txt = $.trim(this.innerHTML); //Get the text of current
        return ($(this).nextAll().filter(function () { //filter all of the proceeding siblings which has the same text
            return $.trim(this.innerHTML) === txt
        }).length); //send true or false (in fact truthy or falsy to ask to hide the current element in question)
    }).hide();

   
});


