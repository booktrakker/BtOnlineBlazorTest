﻿<script>

            /*
    * -------------------------------------------------------
    * Project: arrow
    * Version: 0.1.7
    *
    * Author:  Petar Bojinov
    * Contact: petarbojinov@gmail.com
    *
    *
    * Copyright (c) 2015 Perion
    * -------------------------------------------------------
    */

            /*window.Arrow = function (window, document) {"use strict"; function _increaseOpacity(milliseconds) { var arrow = document.getElementById("arrow-" + browser); arrow.style.display = "block"; var i = 0, ieI = 0, x = setInterval(function () {i += .1, ieI += 10, "msie" === browser && 8 >= browserVersion ? arrow.filters && (arrow.filters.item("DXImageTransform.Microsoft.Alpha").opacity = ieI) : arrow.style.opacity = i}, 50); setTimeout(function () {clearInterval(x)}, 600), setTimeout(function () {_hide()}, milliseconds || 6e3) } function _decreaseOpacity() { var arrow = document.getElementById("arrow-" + browser), i = 1, ieI = 100, x = setInterval(function () {i -= .1, ieI -= 10, "msie" === browser && 8 >= browserVersion ? arrow.filters && (arrow.filters.item("DXImageTransform.Microsoft.Alpha").opacity = ieI) : arrow.style.opacity = i}, 50); setTimeout(function () {clearInterval(x), arrow.style.display = "none"}, 600) } function _applyStyleModern(node) {node.style.position = "fixed", node.style.zIndex = 999, node.style.display = "none", node.style.height = "309px", node.style.width = "186px", node.style.opacity = 0, node.style.backgroundImage = "url(https://i.imgur.com/aMwoyfN.png)", node.style.backgroundRepeat = "no-repeat", node.style.backgroundPositionX = "0", node.style.backgroundPositionY = "0"} function _applyStyleIE8(node) {node.style.top = "10px", node.style.left = "20px"; var opacity = "progid:DXImageTransform.Microsoft.Alpha(opacity=0) ", imgSrc = 'progid:DXImageTransform.Microsoft.AlphaImageLoader(src="https://i.imgur.com/aMwoyfN.png", sizingMethod="scale") ', rotation = 'progid:DXImageTransform.Microsoft.Matrix(M11=1, M12=1.2246063538223773e-16, M21=-1.2246063538223773e-16, M22=-1, SizingMethod="auto expand") '; node.style.filter = opacity + imgSrc + rotation } function _applyStyleMs(node) {node.style.bottom = "50px", node.style.left = "67%"} function _applyStyleMoz(node) {node.style.top = "0px", node.style.right = "37px", node.style.transform = "rotateX(180deg) rotateY(180deg)", node.style.MozTransform = "rotateX(180deg) rotateY(180deg)"} function _applyStyleWebkit(node) {node.style.bottom = "50px", node.style.left = "20px"} function _applyStyleSafari(node) {node.style.top = "0px", node.style.right = "80px", node.style.transform = "rotateX(180deg) rotateY(180deg)", node.style.webkitTransform = "rotateX(180deg) rotateY(180deg)"} function _setStyleType(node) {_applyStyleModern(node), "msie" === browser ? 8 === browserVersion ? _applyStyleIE8(node) : (9 === browserVersion || 10 === browserVersion) && _applyStyleMs(node) : "chrome" === browser || "opera" === browser ? _applyStyleWebkit(node) : "safari" === browser ? _applyStyleSafari(node) : "IE11" === browser || "edge" === browser ? _applyStyleMs(node) : "firefox" === browser && browserVersion >= 20 && _applyStyleMoz(node)} function _buildArrow() { var div = document.createElement("div"); return div.setAttribute("id", "arrow-" + browser), arrowNode = div, div } function _injectNode(node) {document.body.appendChild(node)} function _isExist() { return !!document.getElementById("arrow-" + browser) } function _initArrow() { var arrow = _buildArrow(); _setStyleType(arrow), _calculateArrowPosition(), _injectNode(arrow), _addWindowEvent("resize", _calculateArrowPosition), _addWindowEvent("scroll", _calculateArrowPosition) } function _addWindowEvent(event, functionReference) {window.addEventListener ? window.addEventListener(event, functionReference, !1) : window.attachEvent && window.attachEvent(event, functionReference)} function _calculateArrowPosition() {"number" == typeof window.innerWidth ? (visibleWidth = window.innerWidth, visibleHeight = window.innerHeight) : document.documentElement && (document.documentElement.clientWidth || document.documentElement.clientHeight) && (visibleWidth = document.documentElement.clientWidth, visibleHeight = document.documentElement.clientHeight), "msie" === browser && 9 === browserVersion && (1005 > visibleWidth ? arrowNode.style.bottom = "85px" : visibleWidth > 1006 && (arrowNode.style.bottom = "50px"))} function _hide() { if (!_isExist()) throw "Invalid usage: There are no arrows on the page."; _decreaseOpacity() } function show(seconds) { if (!_isExist()) throw "Invalid usage: arrow does not exist"; _increaseOpacity(seconds) } var arrowNode, version = "0.1.7", Arrow = { }, browser = "", browserVersion = 0, visibleHeight = 0, visibleWidth = 0; return function () { var tem, N = navigator.appName, ua = navigator.userAgent, M = ua.match(/(opera|chrome|safari|firefox|msie)\/?\s*(\.?\d+(\.\d+)*)/i); M && null != (tem = ua.match(/version\/([\.\d]+)/i)) && (M[2] = tem[1]), M = M ? [M[1], M[2]] : [N, navigator.appVersion, "-?"], browser = "netscape" == M[0].toLowerCase() ? "IE11" : -1 != ua.toLowerCase().indexOf("edge") ? "edge" : M[0].toLowerCase(), browserVersion = parseInt(M[1], 10) }(), _initArrow(), Arrow._version = version, Arrow._browser = browser, Arrow._browserVersion = browserVersion, Arrow.show = show, Arrow }(window, window.document);*/

    window.Arrow = function (window, document) {
        "use strict";
    function _increaseOpacity(milliseconds) {
                    var arrow = document.getElementById("arrow-" + browser);
    arrow.style.display = "block";
    var i = 0,
    ieI = 0,
    x = setInterval(function () {
        i += .1,
        ieI += 10,
        "msie" === browser && 8 >= browserVersion ? arrow.filters && (arrow.filters.item("DXImageTransform.Microsoft.Alpha").opacity = ieI) : arrow.style.opacity = i
    }, 50);
    setTimeout(function () {
        clearInterval(x)
    }, 600),
    setTimeout(function () {
        _hide()
    }, milliseconds || 6e3)
                }
    function _decreaseOpacity() {
                    var arrow = document.getElementById("arrow-" + browser),
    i = 1,
    ieI = 100,
    x = setInterval(function () {
        i -= .1,
        ieI -= 10,
        "msie" === browser && 8 >= browserVersion ? arrow.filters && (arrow.filters.item("DXImageTransform.Microsoft.Alpha").opacity = ieI) : arrow.style.opacity = i
    }, 50);
    setTimeout(function () {
        clearInterval(x),
        arrow.style.display = "none"
    }, 600)
                }
    function _applyStyleModern(node) {
        node.style.position = "fixed",
        node.style.zIndex = 999,
        node.style.display = "none",
        node.style.height = "309px",
        node.style.width = "186px",
        node.style.opacity = 0,
        node.style.backgroundImage = "url(https://i.imgur.com/aMwoyfN.png)",
        node.style.backgroundRepeat = "no-repeat",
        node.style.backgroundPositionX = "0",
        node.style.backgroundPositionY = "0"
    }
    function _applyStyleIE8(node) {
        node.style.top = "10px",
        node.style.left = "20px";
    var opacity = "progid:DXImageTransform.Microsoft.Alpha(opacity=0) ",
    imgSrc = 'progid:DXImageTransform.Microsoft.AlphaImageLoader(src="https://i.imgur.com/aMwoyfN.png", sizingMethod="scale") ',
    rotation = 'progid:DXImageTransform.Microsoft.Matrix(M11=1, M12=1.2246063538223773e-16, M21=-1.2246063538223773e-16, M22=-1, SizingMethod="auto expand") ';
    node.style.filter = opacity + imgSrc + rotation
                }
    function _applyStyleMs(node) {
        node.style.bottom = "0px",
        node.style.left = "67%"

    }

    function _applyStyleEdge(node) {
        node.style.top = "100px",
        node.style.right = "150px",
        node.style.transform = "rotateX(180deg) rotateY(180deg)",
        node.style.MozTransform = "rotateX(180deg) rotateY(180deg)"
    }

    function _applyStyleWebkit(node) {
        node.style.bottom = "0px",
        node.style.left = "77px"
        //node.style.transform = "rotateX(180deg) rotateY(180deg)",
        //    node.style.MozTransform = "rotateX(180deg) rotateY(180deg)"

    }

    function _applyStyleMoz(node) {
        node.style.top = "0px",
        node.style.right = "37px",
        node.style.transform = "rotateX(180deg) rotateY(180deg)",
        node.style.MozTransform = "rotateX(180deg) rotateY(180deg)"
    }
                //function _applyStyleWebkit(node) {
        //    node.style.top = "100px",
        //        node.style.right = "150px",
        //        node.style.transform = "rotateX(180deg) rotateY(180deg)",
        //        node.style.MozTransform = "rotateX(180deg) rotateY(180deg)"
        //}
        function _applyStyleSafari(node) {
            node.style.top = "0px",
                node.style.right = "80px",
                node.style.transform = "rotateX(180deg) rotateY(180deg)",
                node.style.webkitTransform = "rotateX(180deg) rotateY(180deg)"
        }
                function _setStyleType(node) {
        _applyStyleModern(node),
        "msie" === browser ? 8 === browserVersion ? _applyStyleIE8(node) : (9 === browserVersion || 10 === browserVersion) && _applyStyleMs(node) : "chrome" === browser || "opera" === browser ? _applyStyleWebkit(node) : "safari" === browser ? _applyStyleSafari(node) : "IE11" === browser || "edge" === browser ? _applyStyleEdge(node) : "firefox" === browser && browserVersion >= 20 && _applyStyleMoz(node)
    }
    function _buildArrow() {
                    var div = document.createElement("div");
    return div.setAttribute("id", "arrow-" + browser),
    arrowNode = div,
    div
                }
    function _injectNode(node) {
        document.body.appendChild(node)
    }
    function _isExist() {
                    return !!document.getElementById("arrow-" + browser)
                }
    function _initArrow() {
                    var arrow = _buildArrow();
    _setStyleType(arrow),
    _calculateArrowPosition(),
    _injectNode(arrow),
    _addWindowEvent("resize", _calculateArrowPosition),
    _addWindowEvent("scroll", _calculateArrowPosition)
                }
    function _addWindowEvent(event, functionReference) {
        window.addEventListener ? window.addEventListener(event, functionReference, !1) : window.attachEvent && window.attachEvent(event, functionReference)
    }
    function _calculateArrowPosition() {
        "number" == typeof window.innerWidth ? (visibleWidth = window.innerWidth, visibleHeight = window.innerHeight) : document.documentElement && (document.documentElement.clientWidth || document.documentElement.clientHeight) && (visibleWidth = document.documentElement.clientWidth, visibleHeight = document.documentElement.clientHeight),
        "msie" === browser && 9 === browserVersion && (1005 > visibleWidth ? arrowNode.style.bottom = "85px" : visibleWidth > 1006 && (arrowNode.style.bottom = "50px"))
    }
    function _hide() {
                    if (!_isExist())
    throw "Invalid usage: There are no arrows on the page.";
    _decreaseOpacity()
                }
    function show(seconds) {
                    if (!_isExist())
    throw "Invalid usage: arrow does not exist";
    _increaseOpacity(seconds)
                }
    function isEdge() {
                    for (brand_version_pair of navigator.userAgentData.brands) {
                        if (brand_version_pair.brand == "Microsoft Edge") {
                            return true;
                        }
                    }
    return false;
                }
    var arrowNode,
    version = "0.1.7",
    Arrow = { },
    browser = "",
    browserVersion = 0,
    visibleHeight = 0,
    visibleWidth = 0;
    return function () {
                    var tem,
    N = navigator.appName,
    ua = navigator.userAgent,
    M = ua.match(/(opera|chrome|safari|firefox|msie)\/?\s*(\.?\d+(\.\d+)*)/i);
    M && null != (tem = ua.match(/version\/([\.\d]+)/i)) && (M[2] = tem[1]),
    M = M ? [M[1], M[2]] : [N, navigator.appVersion, "-?"],
    //browser = "netscape" == M[0].toLowerCase() ? "IE11" : isEdge() ? "edge" : M[0].toLowerCase(),
    browser = "netscape" == M[0].toLowerCase() ? "IE11" : -1 != ua.toLowerCase().indexOf("edg") ? "edge" : M[0].toLowerCase(),
    browserVersion = parseInt(M[1], 10);

                    //isEdge() ? browser = "edge" : browser = browser


                }
    (),
    _initArrow(),
    Arrow._version = version,
    Arrow._browser = browser,
    Arrow._browserVersion = browserVersion,
    Arrow.show = show,
    Arrow
            }
    (window, window.document);

</script>