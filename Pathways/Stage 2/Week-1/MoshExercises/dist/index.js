"use strict";
function kgToLBS(weight) {
    if (typeof weight === "number") {
        return weight * 2.2;
    }
    else {
        return parseInt(weight) * 2.2;
    }
}
kgToLBS(10);
kgToLBS("10kg");
//# sourceMappingURL=index.js.map