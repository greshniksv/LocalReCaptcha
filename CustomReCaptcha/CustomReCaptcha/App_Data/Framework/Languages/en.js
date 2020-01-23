CustomRecaptcha.prototype.language = function (key) {

    switch (key) {
        case "welcome": return "Welcome";
        case "verify": return "Verify";
        default: return "ERROR";
    }

}