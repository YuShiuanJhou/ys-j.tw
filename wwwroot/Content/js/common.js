function hasClass(ele, cls) {
    return !!ele.className.match(new RegExp('(\\s|^)' + cls + '(\\s|$)'));
}

function addClass(ele, cls) {
    if (!hasClass(ele, cls)) ele.className += " " + cls;
}

function removeClass(ele, cls) {
    if (hasClass(ele, cls)) {
        var reg = new RegExp('(\\s|^)' + cls + '(\\s|$)');
        ele.className = ele.className.replace(reg, ' ');
    }
}

function scrollTo(id) {
    if (window.location.pathname === "/") {
        document.getElementById(id).scrollIntoView({
            behavior: 'smooth'
        });
    } else {
        if (!(window.location.pathname.toLowerCase() === "/sideprojects" && id === "section-sideProjects")) {
            window.location = `/#${id}`;
        }
    }
}


(function () {
    console.log(window.location.hash);

})();


document.getElementById("nav-about").addEventListener('click', function () { scrollTo("section-about") }, false);
document.getElementById("nav-projects").addEventListener('click', function () { scrollTo("section-projects") }, false);
document.getElementById("nav-sideProjects").addEventListener('click', function () { scrollTo("section-sideProjects") }, false);
document.getElementById("nav-site").addEventListener('click', function () { scrollTo("section-siteInfo") }, false);

document.getElementById("nav-about-mobile").addEventListener('click', function () { scrollTo("section-about") }, false);
document.getElementById("nav-projects-mobile").addEventListener('click', function () { scrollTo("section-projects") }, false);
document.getElementById("nav-sideProjects-mobile").addEventListener('click', function () { scrollTo("section-sideProjects") }, false);
document.getElementById("nav-site-mobile").addEventListener('click', function () { scrollTo("section-siteInfo") }, false);

var navMobileToggleLink = document.getElementById("nav-mobile-toggle-link");
var navMobileCloseLink = document.getElementById("nav-mobile-close-link");
var navMobile = document.getElementById("nav-mobile");


navMobileToggleLink.addEventListener('click', function () {
    if (!hasClass(navMobile, "show")) {
        addClass(navMobile, "show");
    }
}, false);

navMobileCloseLink.addEventListener('click', function () {
    if (hasClass(navMobile, "show")) {
        removeClass(navMobile, "show");
    }
}, false);

navMobile.addEventListener('click', function () {
    if (hasClass(navMobile, "show")) {
        removeClass(navMobile, "show");
    }
}, false);