function addTooltip() {
    init()
}

function init() {
    M.Tooltip.init(document.querySelectorAll('.tooltipped'));
    M.Modal.init(document.querySelectorAll('.modal'));
    M.Collapsible.init(document.querySelectorAll('.collapsible'));
    M.Sidenav.init(document.querySelectorAll('.sidenav'));
    M.Tabs.init(document.querySelectorAll('.tabs'));
    console.log("started");
}

function initBrowser() {

    let settings = [];
    let count = 14;
    for (var i = 1; i < count ; i++) {
        let obj =             {
            breakpoint: 2500 - (180 * i),
            settings: {
                slidesToShow: count - (i + 1),
                slidesToScroll: 1
            }
        };
        settings.push(obj)
    }
    


    $('.last-seen-carousel').slick({
        slidesToShow: count,
        slidesToScroll: 1,
        speed: 300,
        nextArrow: $("#last-seen-next"),
        prevArrow: $("#last-seen-prev"),
        responsive: settings,
    });
    
    $('.new-downloaded-carousel').slick({
        slidesToShow: count,
        slidesToScroll: 1,
        speed: 300,
        nextArrow: $("#new-downloaded-next"),
        prevArrow: $("#new-downloaded-prev"),
        responsive: settings,
    });
}