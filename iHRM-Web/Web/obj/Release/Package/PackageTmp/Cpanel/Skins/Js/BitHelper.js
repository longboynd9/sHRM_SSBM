
var BitHelper = {
    /// kiểm tra bit trong num ko
    bit_has: function (num, bit) {
        return (num & bit) == bit;
    },

    /// thêm giá trị bit vào num
    bit_set: function (num, bit) {
        return num | bit;
    },

    /// xóa giá trị bit trong num
    bit_clear: function (num, bit) {
        return num & ~bit;
    },

    /// đảo bit trong num
    bit_toggle: function (num, bit) {
        return num ^ bit;
    }
}