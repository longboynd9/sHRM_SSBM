/**
 * @class GetIt.GridPrinter
 * @author Ed Spencer (edward@domine.co.uk)
 * Helper class to easily print the contents of a grid. Will open a new window with a table where the first row
 * contains the headings from your column model, and with a row for each item in your grid's store. When formatted
 * with appropriate CSS it should look very similar to a default grid. If renderers are specified in your column
 * model, they will be used in creating the table. Override headerTpl and bodyTpl to change how the markup is generated
 * 
 * Usage:
 * 
 * var grid = new Ext.grid.GridPanel({
 *   colModel: //some column model,
 *   store   : //some store
 * });
 * 
 * Ext.ux.GridPrinter.print(grid);
 * 
 */
$(document).ready(function () {
    Ext.onReady(function () {

        Ext.ux.GridPrinter = {
            /**
             * Prints the passed grid. Reflects on the grid's column model to build a table, and fills it using the store
             * @param {Ext.grid.GridPanel} grid The grid to print
             */
            print: function (grid) {
                //We generate an XTemplate here by using 2 intermediary XTemplates - one to create the header,
                //the other to create the body (see the escaped {} below)
                var columns = grid.getColumnModel().config;

                //build a useable array of store data for the XTemplate
                var data = [];
                var rowNumberer = 0;

                //use the headerTpl and bodyTpl XTemplates to create the main XTemplate below
                var headings = Ext.ux.GridPrinter.headerTpl.apply(columns);
                var body = ''; //Ext.ux.GridPrinter.bodyTpl.apply(columns);

                Ext.each(columns, function (column) {
                    var key = column.dataIndex;
                    if (key == '') {
                        if (column.isRowNumberer) key = 'RowNumberer';
                    }

                    body += '<td>{' + key + '}</td>';
                });

                grid.store.data.each(function (item) {
                    var convertedData = [];

                    Ext.each(columns, function(column){
                        var key = column.dataIndex;                    
                        var value = item.get(key);

                        if (key == '') {
                            if (column.isRowNumberer) {
                                convertedData['RowNumberer'] = ++rowNumberer;
                                key = 'RowNumberer';
                            }
                        }
                        //else if (Ext.ClassManager.getName(column) == 'Ext.grid.column.Template') {
                        //    convertedData[key] = column.tpl ? column.tpl.apply(item.data) : value;
                        //}
                        else {
                            convertedData[key] = column.renderer ? column.renderer(value) : value;
                        }
                    });

                    data.push(convertedData);
                });

                var html = new Ext.XTemplate(
                  '<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">',
                  '<html>',
                    '<head>',
                      '<meta content="text/html; charset=UTF-8" http-equiv="Content-Type" />',
                      '<link href="' + Ext.ux.GridPrinter.stylesheetPath + '" rel="stylesheet" type="text/css" media="screen,print" />',
                      '<title>report</title>',
                      '<style type="text/css">html,body,div,dl,dt,dd,ul,ol,li,h1,h2,h3,h4,h5,h6,pre,form,fieldset,input,p,blockquote,th,td\{margin:0;padding:0;\} img,body,html\{border:0;\} address,caption,cite,code,dfn,em,strong,th,var\{font-style:normal;font-weight:normal;\} ol,ul \{list-style:none;\} caption,th \{text-align:left;\} h1,h2,h3,h4,h5,h6\{font-size:100%;\} q:before,q:after\{content:"";\}   table.report \{   width: 100%;   text-align: left;   font-size: 11px;   font-family: arial;   border-collapse: collapse; \}   table.report th \{   padding: 4px 3px 4px 5px;   border: 1px solid #d0d0d0;   border-left-color: #eee;   background-color: #ededed;   text-align:center; font-weight:bold; \}   table.report td \{   padding: 4px 3px 4px 5px;   border-style: none solid solid;   border-width: 1px;   border-color: #ededed; \}   table.head \{     width: 100%; margin-bottom: 5px; \} table.head .BC_donvi \{     width:220px; vertical-align:top; \} table.head .BC_donvi h4 \{     font-size:13px; \}  table.head .BC_tieude \{     text-align:center; padding-right: 220px; \} table.head .BC_tieude h2\{     font-size: 20px; \} table.head .BC_filter \{     font-size:16px; font-weight:600; \} table.head .BC_desciption \{     text-align:right; font-style:italic; color:#4f4f4f; \}</style>',
                    '</head>',
                    '<body>',
                      '<table class="head"><tr><td class="BC_donvi"><h4>' + Ext.ux.GridPrinter.BC_donvi + '<h4></td><td class="BC_tieude"><h2>' + Ext.ux.GridPrinter.BC_tieude + '</h2><p class="BC_filter">' + Ext.ux.GridPrinter.BC_filter + '</p></td><td></td></tr><tr><td class="BC_desciption" colspan="3"><p>' + Ext.ux.GridPrinter.BC_desciption + '</p></td></tr></table>',
                      '<table class="report">',
                        headings,
                        '<tpl for=".">',
                            '<tr>',
                                body,
                            '</tr>',
                        '</tpl>',
                      '</table>',
                    '</body>',
                  '</html>'
                ).apply(data);

                //open up a new printing window, write to it, print it and close
                var win = window.open('', 'printgrid');

                win.document.write(html);

                win.print();
                win.close();
            },

            /**
             * @property stylesheetPath
             * @type String
             * The path at which the print stylesheet can be found (defaults to '/stylesheets/print.css')
             */
            stylesheetPath: '/Cpanel/Skins/Js/gridprinter6.css',

            BC_donvi : 'PHÒNG GD - ĐT KỲ SƠN',
            BC_tieude : '',
            BC_filter : '',
            BC_desciption : '',

            /**
             * @property headerTpl
             * @type Ext.XTemplate
             * The XTemplate used to create the headings row. By default this just uses <th> elements, override to provide your own
             */
            headerTpl: new Ext.XTemplate(
              '<tr>',
                '<tpl for=".">',
                  '<th>{header}</th>',
                '</tpl>',
              '</tr>'
            ),

            /**
             * @property bodyTpl
             * @type Ext.XTemplate
             * The XTemplate used to create each row. This is used inside the 'print' function to build another XTemplate, to which the data
             * are then applied (see the escaped dataIndex attribute here - this ends up as "{dataIndex}")
             */
            bodyTpl: new Ext.XTemplate(
              '<tr>',
                '<tpl for=".">',
                  '<td>\{{dataIndex}\}</td>',
                '</tpl>',
              '</tr>'
            )
        };
    });
});