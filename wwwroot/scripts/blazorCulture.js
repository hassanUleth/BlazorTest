//window.blazorCulture = {
//    get: () => localStorage["BlazorCulture"],
//    set: (value) => localStorage["BlazorCulture"] = value
//};

export function getBlazorCulture() {
    return window.localStorage["BlazorCulture"];
};
export function setBlazorCulture(value) {
    window.localStorage["BlazorCulture"] = value;
};
