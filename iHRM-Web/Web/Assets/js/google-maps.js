
function getNoneUnicode(val) {
    // author url: http://canthoit.info/demo-locdau-js.html
    var str = val.toLowerCase();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    return str;
}

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

function getDistricts(provinceId) {
    if (provinceId != '-1') {
        var root = location.protocol + '//' + location.host;
        $.post(root + "/AjaxAction.aspx", {
            action: "get-districts",
            provinceId: provinceId
        }, function (response) {
            $('#cboDistrict').html(response);

            var districtId = getParameterByName("districtId");
            var proId = getParameterByName("provinceId");
            if (districtId != '') {
                $('#cboDistrict').val(districtId);
                getMarket(provinceId, districtId, 3);
            }

            if (provinceId != proId) {
                $('#cboDistrict').val('-1');
            }
        });
    }
}

function getMarket(provinceId, districtId, shopId) {
    var root = location.protocol + '//' + location.host;
    $.post(root + "/AjaxAction.aspx", {
        action: "get-markets",
        provinceId: provinceId,
        districtId: districtId,
        shopId: shopId
    }, function (response) {
        $('#store-address').html(response);
        $('#google-maps').show();

        // Load market location
        maininitialize();
        google.maps.event.addDomListener(window, 'load', maininitialize);
    });
}

function loadMarker(map, isload) {
    var provinceId = getParameterByName("provinceId");
    if (!GMapLoaded && provinceId != '') {
        var districId = jQuery('#cboDistrict option:selected').val();

        if (districId == null || districId == "") {
            districId = -1;
        }

        provinceId = jQuery('#cboProvince option:selected').val();
        var root = location.protocol + '//' + location.host;

        $.post(root + "/AjaxAction.aspx", {
            action: "get-markets",
            provinceId: provinceId,
            districtId: districId,
            shopId: 3
        }, function (response) {
            $('#store-address').html(response);
            $('#google-maps').show();
            addMarker(map);
            if (isload) {
                if (provinceId != '') {
                    getDistricts(provinceId);
                }
            }
        });
    } else {
        addMarker(map);
    }
}

function addMarker(map) {
    var $province = jQuery('#cboProvince option:selected');
    var lat = $province.data('latitude');
    var lon = $province.data('longtitude');

    if (lat && lon) {
        map.setCenter(new google.maps.LatLng(lat, lon));
    } else {
        var geocoder = new google.maps.Geocoder();
        geocoder.geocode({
            'address': $province.text() + ', Việt Nam'
        },
            function (results, status) {
                if (results) {
                    map.setCenter(results[0].geometry.location);
                }
            }
        );
    }

    var locations = new Array();
    var index = 1;
    jQuery('#store-address i').each(function (idx, elm) {
        var e = $(elm);
        locations.push(new Array('Siêu thị ' + e.data('name'), e.data('latitude'), e.data('longtitude'), e.data(''), index));
        index += 1;
    });

    var marker, i;
    var shopIcon = '/Assets/images/shop.png';
    var infowindow = new google.maps.InfoWindow();
    for (i = 0; i < locations.length; i++) {
        marker = new google.maps.Marker({
            position: new google.maps.LatLng(locations[i][1], locations[i][2]),
            map: map,
            category: shopIcon,
            icon: shopIcon,
            title: 'Click để xem vị trí siêu thị trên bản đồ.'
        });

        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                infowindow.setContent(locations[i][0]);
                infowindow.open(map, marker);
            };
        })(marker, i));
    }
}

function initialize() {
    var latitude = jQuery('#google-maps-canvas').data('latitude');
    var longtitude = jQuery('#google-maps-canvas').data('longtitude');

    var mapOptions = {
        zoom: 14,
        center: new google.maps.LatLng(latitude, longtitude),
        mapTypeId: google.maps.MapTypeId.ROADMAP,

        mapTypeControl: true,
        mapTypeControlOptions: {
            style: google.maps.MapTypeControlStyle.HORIZONTAL_BAR,
            position: google.maps.ControlPosition.TOP_RIGHT
        },
        panControl: true,
        panControlOptions: {
            position: google.maps.ControlPosition.TOP_RIGHT
        },
        zoomControl: true,
        zoomControlOptions: {
            style: google.maps.ZoomControlStyle.LARGE,
            position: google.maps.ControlPosition.TOP_RIGHT
        },
        scaleControl: true,
        scaleControlOptions: {
            position: google.maps.ControlPosition.TOP_LEFT
        },
        streetViewControl: true,
        streetViewControlOptions: {
            position: google.maps.ControlPosition.LEFT_TOP
        }
    };

    var map = new google.maps.Map(document.getElementById('google-maps-canvas'), mapOptions);
    var shopIcon = '/Assets/images/shop.png';
    var marker = new google.maps.Marker({
        position: map.getCenter(),
        map: map,
        category: shopIcon,
        icon: shopIcon,
        title: 'Click để xem vị trí siêu thị trên bản đồ.'
    });

    google.maps.event.addListener(map, 'center_changed', function () {
        // 30 seconds after the center of the map has changed, pan back to the marker.
        window.setTimeout(function () {
            map.panTo(marker.getPosition());
        }, 30000);
    });

    var storeName = jQuery('#storeName').data('name');
    var infowindow = new google.maps.InfoWindow({
        content: storeName,
        maxWidth: 250
    });

    google.maps.event.addListener(marker, 'click', function () {
        map.setZoom(18);
        map.setCenter(marker.getPosition());
        infowindow.open(map, marker);
    });
}

var GMapLoaded = false;

function maininitialize() {

    $('#google-maps').show();

    var zoomNum;
    var $province = jQuery('#cboProvince option:selected');
    if ($province.val() == '-1') {
        zoomNum = 5;
    } else {
        zoomNum = 11;
    }

    var lat = $province.data('latitude');
    var lon = $province.data('longtitude');

    var map = new google.maps.Map(document.getElementById('google-maps'), {
        zoom: zoomNum,
        center: new google.maps.LatLng(lat, lon),
        mapTypeId: google.maps.MapTypeId.ROADMAP,

        mapTypeControl: true,
        mapTypeControlOptions: {
            style: google.maps.MapTypeControlStyle.HORIZONTAL_BAR,
            position: google.maps.ControlPosition.TOP_RIGHT
        },
        panControl: true,
        panControlOptions: {
            position: google.maps.ControlPosition.TOP_RIGHT
        },
        zoomControl: true,
        zoomControlOptions: {
            style: google.maps.ZoomControlStyle.LARGE,
            position: google.maps.ControlPosition.TOP_RIGHT
        },
        scaleControl: true,
        scaleControlOptions: {
            position: google.maps.ControlPosition.TOP_LEFT
        },
        streetViewControl: true,
        streetViewControlOptions: {
            position: google.maps.ControlPosition.LEFT_TOP
        }
    });

    if (!GMapLoaded && navigator.geolocation && $province.val() != '-1') {
        window.setTimeout(function () {
            loadMarker(map, true);
        }, 1500);

        var myMap;
        navigator.geolocation.getCurrentPosition(function (position) {
            var geocoder = new google.maps.Geocoder();
            var latlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);

            myMap = new google.maps.Map(document.getElementById('google-maps'), {
                zoom: 11,
                center: new google.maps.LatLng(position.coords.latitude, position.coords.longitude),
                mapTypeId: google.maps.MapTypeId.ROADMAP,

                mapTypeControl: true,
                mapTypeControlOptions: {
                    style: google.maps.MapTypeControlStyle.HORIZONTAL_BAR,
                    position: google.maps.ControlPosition.TOP_RIGHT
                },
                panControl: true,
                panControlOptions: {
                    position: google.maps.ControlPosition.TOP_RIGHT
                },
                zoomControl: true,
                zoomControlOptions: {
                    style: google.maps.ZoomControlStyle.LARGE,
                    position: google.maps.ControlPosition.TOP_RIGHT
                },
                scaleControl: true,
                scaleControlOptions: {
                    position: google.maps.ControlPosition.TOP_LEFT
                },
                streetViewControl: true,
                streetViewControlOptions: {
                    position: google.maps.ControlPosition.LEFT_TOP
                }
            });

            geocoder.geocode({ latLng: latlng }, function (results, status) {
                if (results[1]) {
                    var addrs = results[1].address_components;
                    var len = addrs.length;
                    var address = getNoneUnicode(addrs[len - 2].long_name);

                    var opt;
                    jQuery('#cboProvince option').each(function (idx) {

                        var txt = getNoneUnicode(jQuery(this).text());

                        if (address == txt) {
                            opt = $(this);
                            return;

                        } else {
                            address = address.replace(/[^\w\s]/gi, ' '); // bo dau tru
                            address = address.replace(/\s+/g, ' '); // chi giu lai 1 dau cach

                            txt = txt.replace(/[^\w\s]/gi, ' ');
                            txt = txt.replace(/\s+/g, ' ');

                            if (address == txt) {
                                opt = $(this);
                                return;
                            }
                        }
                    });

                    if (opt) {
                        $('#cboProvince option[value="' + opt.val() + '"]').attr('selected', 'selected');

                        $("#divDistrict").show();
                        getDistricts(opt.val());
                    }

                    loadMarker(myMap, true);
                    GMapLoaded = true;
                }
            });
        }, function () {
            loadMarker(myMap, true);
            GMapLoaded = true;
        }, { timeout: 1000, enableHighAccuracy: true });
    } else {
        loadMarker(map);
        GMapLoaded = true;
    }
}

(function ($) {
    $(document).ready(function () {
        if ($("#google-maps-canvas").length > 0) {
            google.maps.event.addDomListener(window, 'load', initialize);
        }
    });

    $(window).load(function () {
        maininitialize();
    });

})(jQuery);


