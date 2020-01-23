function CustomRecaptcha() {

    var baseUrl = "BaseUrl"; //#BaseUrl
    var languageKey = 'en'; //#LanguageKey
    var instance = "";
    var successCallback = null;

    var isFunction = function (functionToCheck) {
        return functionToCheck && {}.toString.call(functionToCheck) === '[object Function]';
    }

    if (typeof jQuery == 'undefined') {
        console.exception("jQuery not loaded. CustomRecaptcha will not work!");
    }

    this.render = function (element, parameters) {
        var $container = $("#" + element);
        var clientKey = $container.attr("data-sitekey");
        var timestamp = new Date().getTime();
        var self = this;

        if (typeof parameters !== "undefined" &&
            parameters != null &&
            typeof parameters.callback !== "undefined") {

            if (isFunction(parameters.callback) === false) {
                console.exception("Callback parameter is not a function!");
            }

            successCallback = parameters.callback;
        }

        $container.append(
            "<textarea id='g-recaptcha-response' type='hidden' name='g-recaptcha-response' style='display:none'/>");
        if (typeof clientKey === "undefined") {
            console.exception("Attribute: 'data-sitekey' is not defined!");
        }

        var getInstance = baseUrl + "api/Verification?clientKey=" + clientKey;
        $.getJSON(getInstance, function (data) {
            instance = data.Instance;
            var getImage = baseUrl + "api/VerificationData?clientKey=" + clientKey +
                "&type=0&instance=" + data.Instance + "&lang=" + languageKey +  "&t=" + timestamp;
            var getAudio = baseUrl + "api/VerificationData?clientKey=" + clientKey +
                "&type=1&instance=" + data.Instance + "&lang=" + languageKey + "&t=" + timestamp;

            $container.append("<iframe id='g_frame' frameborder='0' scrolling='no' " +
                "sandbox='allow-forms allow-popups allow-same-origin allow-scripts allow-top-navigation " +
                "allow-modals allow-popups-to-escape-sandbox' width='304px' height='85px' ></iframe>");

            var content =
                "   <div id='g_container'>" +
                "       <div id='g_data_container'>" +
                "           <div id='g_data'> <img src='" + getImage + "' /> </div>" +
                "           <div id='g_data_audio'> " +
                "                       <img src='" + baseUrl + "Content/Framework/audio.png'  " +
                "                            onclick='window.parent.grecaptcha.audioPlay()' /> " +
                "           </div>" +
                "           <div id='g_data_reset'> " +
                "                       <img src='" + baseUrl + "Content/Framework/reset.png'  " +
                "                            onclick='window.parent.grecaptcha.reset(\"" + element + "\")' /> " +
                "           </div>" +
                "           <div id='g_audio_container'>" +
                "               <audio preload='none' id='g_audio'> " + 
                "                   <source src='' g-url='" + getAudio + "' type='audio/mpeg'> "+
                "                   Your browser does not support the audio element. "+
                "               </audio> "+
                "           </div> "+
                "       </div>"+
                "       <div id='g_answer_container'> " +
                "           <input id='g_answer' type='text' /> " +
                "           <input id='g_button' type='button' " +
                "                   onclick='window.parent.grecaptcha.verify(\"" + element + "\")' " +
                "                      value='" + self.language("verify") + "' /> " +
                "       </div>" +
                "   </div>";

            var link = "<link rel='stylesheet' type='text/css' href='" + baseUrl + "Content/Framework/framework.css'>";

            $('#g_frame').contents().find('body').append(content);
            $('#g_frame').contents().find('head').append(link);

        });
        return element;
    }

    this.audioPlay = function () {
        var audio = $("#g_frame").contents().find("#g_audio source");
        audio.attr("src", audio.attr("g-url"));
        $("#g_frame").contents().find("#g_audio").trigger("load");
        $("#g_frame").contents().find("#g_audio").trigger("play");
    }

    this.verify = function (element) {
        var $container = $("#" + element);
        var clientKey = $container.attr("data-sitekey");
        var response = $("#g_frame").contents().find("#g_answer").val();
        var url = baseUrl + "api/Verification?clientKey=" + clientKey +
            "&instance=" + instance + "&clientResponse=" + response;

        $.post(url, function (incoming) {
            if (incoming.success === true) {
                $("#g-recaptcha-response").val(incoming.data);
                var $iframe = $("#g_frame").contents();
                $iframe.find("#g_data_container").remove();
                $iframe.find("#g_answer_container").remove();
                $iframe.find("#g_container").append(
                    "<div id='g_success' style='display:none' >"+
                    "   <img src='" + baseUrl + "Content/Framework/success.png' />" +
                    "</div>");

                if (typeof successCallback !== "undefined" && successCallback !== null) {
                    $iframe.find("#g_success").fadeIn(2000, function() {
                        successCallback();
                    });
                }

            } else {
                grecaptcha.reset(element);
            }
        });
    }

    this.reset = function (element) {
        var $container = $("#" + element);
        $("#g_frame").contents().find("#g_audio").trigger("pause");
        var clientKey = $container.attr("data-sitekey");
        var url = baseUrl + "api/VerificationData?clientKey=" + clientKey + "&instance=" + instance;
        var timestamp = new Date().getTime();
        var getImage = baseUrl + "api/VerificationData?clientKey=" +
            clientKey + "&type=0&instance=" + instance + "&lang=" + languageKey +  "&t=" + timestamp;
        var getAudio = baseUrl + "api/VerificationData?clientKey=" + clientKey +
            "&type=1&instance=" + instance + "&lang=" + languageKey + "&t=" + timestamp;
        $("#g_frame").contents().find("#g_audio_container audio").remove();

        console.log("Start reset");

        setTimeout(function() {

            $.post(url, function (data) {
                if (data.success === true) {
                    $("#g_frame").contents().find("#g_data img").attr("src", getImage);

                    var player =
                        "<audio preload='none' id='g_audio'> " +
                            "   <source src='' g-url='" + getAudio + "' type='audio/mpeg'> " +
                            "   Your browser does not support the audio element. " +
                            "</audio> ";
                    $("#g_frame").contents().find("#g_audio_container").append(player);
                    console.log("Reset success");
                } else {
                    console.error("Can not reset verification object");
                }
            }).fail(function (msg) {
                console.error("Can not reset verification object");
            }).always(function () {
                console.log("always");
            });

        }, 500);

    }
}

//#LanguageData

var grecaptcha = new CustomRecaptcha();
