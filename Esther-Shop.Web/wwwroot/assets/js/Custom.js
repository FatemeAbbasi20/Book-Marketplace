$(document).ready(function(){
    LoadckEditor4();
});




function LoadckEditor4() {
    if (!document.getElementById("ckeditor4"))
        return;
    $("body").append("<script src='ckeditor4/ckeditor/ckeditor.js'></script>");
    CKEDITOR.Replace('ckeditor4', { customConfing: 'ckeditor4/ckeditor/confing.js' });
}

function ChangePage(pageId)
{
    var url = new Url(Window.location.href);
    var searchParams = url.searchParams;
    searchParams.set('pageId', pageId);
    var SP = searchParams.toString();
    var new_url = url.toString();
    window.location.replace(new_url);
      

}

function updatePrice(min, max)
{
    document.querySelector('[name="MaxPrice"]').value = max;
    document.querySelector('[name="MinPrice"]').value = min;

}
