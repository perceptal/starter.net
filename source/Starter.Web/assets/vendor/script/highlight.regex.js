/*
 * jQuery Highlight Regex Plugin v0.1.1
 *
 * Based on highlight v3 by Johann Burkard
 * http://johannburkard.de/blog/programming/javascript/highlight-javascript-text-higlighting-jquery-plugin.html
 *
 * (c) 2009-10 Jacob Rothstein
 * MIT license
 */
(function(a) {
 var b = function(c) {
  if ( !! c && !! c.childNodes) {
   var d = a.makeArray(c.childNodes),
       e = null;
   a.each(d, function(a, d) {
    d.nodeType === 3 ? d.nodeValue === "" ? c.removeChild(d) : e !== null ? (e.nodeValue += d.nodeValue, c.removeChild(d)) : e = d : (e = null, d.childNodes && b(d));
   })
  }
 };
 a.fn.highlight_regex = function(c, d) {
  typeof d == "undefined" && (d = {}), d.className = d.className || "highlight", d.tagType = d.tagType || "span", typeof c == "undefined" || c.source === "" ? a(this).find(d.tagType + "." + d.className).each(function() {
   a(this).replaceWith(a(this).text()), b(a(this).parent().get(0))
  }) : a(this).each(function() {
   var e = a(this).get(0);
   b(e), a.each(a.makeArray(e.childNodes), function(e, f) {
    var g, h, i, j, k, l;
    b(f);
    if (f.nodeType == 3) while (f.data && (j = f.data.search(c)) >= 0) {
     k = f.data.slice(j).match(c)[0];
     if (k.length > 0) g = document.createElement(d.tagType), g.className = d.className, l = f.parentNode, h = f.splitText(j), f = h.splitText(k.length), i = h.cloneNode(!0), g.appendChild(i), l.replaceChild(g, h);
     else break
    } else a(f).highlight_regex(c, d);
   })
  });
  return a(this);
 }
})(jQuery)
