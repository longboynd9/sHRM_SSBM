function Nz(num) {
    if (num == undefined || num == NaN || num == null)
        return 0;
    return num;
}

function FNum(num, format) {
    if (format == undefined)
        format = '0,000.00';
    return Ext.util.Format.number(num, format);
}