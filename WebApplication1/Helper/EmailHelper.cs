
namespace WebApplication1.Helper
{
    public class EmailHelper
    {
        public static string GetDiscountTemplate(string message)
        {
            return $@"<!DOCTYPE html>
<html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml"" xmlns:v=""urn:schemas-microsoft-com:vml""
    xmlns:o=""urn:schemas-microsoft-com:office:office"">

<head>
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""x-apple-disable-message-reformatting"">
    <title></title>
    <style id="""" media=""all"">
        /* cyrillic */
        @font-face {{
            font-family: 'Playfair Display';
            font-style: italic;
            font-weight: 400;
            font-display: swap;
            src: url(/fonts.gstatic.com/s/playfairdisplay/v36/nuFkD-vYSZviVYUb_rj3ij__anPXDTnohkk72xU.woff2) format('woff2');
            unicode-range: U+0301, U+0400-045F, U+0490-0491, U+04B0-04B1, U+2116;
        }}

        /* vietnamese */
        @font-face {{
            font-family: 'Playfair Display';
            font-style: italic;
            font-weight: 400;
            font-display: swap;
            src: url(/fonts.gstatic.com/s/playfairdisplay/v36/nuFkD-vYSZviVYUb_rj3ij__anPXDTnojUk72xU.woff2) format('woff2');
            unicode-range: U+0102-0103, U+0110-0111, U+0128-0129, U+0168-0169, U+01A0-01A1, U+01AF-01B0, U+0300-0301, U+0303-0304, U+0308-0309, U+0323, U+0329, U+1EA0-1EF9, U+20AB;
        }}

        /* latin-ext */
        @font-face {{
            font-family: 'Playfair Display';
            font-style: italic;
            font-weight: 400;
            font-display: swap;
            src: url(/fonts.gstatic.com/s/playfairdisplay/v36/nuFkD-vYSZviVYUb_rj3ij__anPXDTnojEk72xU.woff2) format('woff2');
            unicode-range: U+0100-02AF, U+0304, U+0308, U+0329, U+1E00-1E9F, U+1EF2-1EFF, U+2020, U+20A0-20AB, U+20AD-20CF, U+2113, U+2C60-2C7F, U+A720-A7FF;
        }}

        /* latin */
        @font-face {{
            font-family: 'Playfair Display';
            font-style: italic;
            font-weight: 400;
            font-display: swap;
            src: url(/fonts.gstatic.com/s/playfairdisplay/v36/nuFkD-vYSZviVYUb_rj3ij__anPXDTnogkk7.woff2) format('woff2');
            unicode-range: U+0000-00FF, U+0131, U+0152-0153, U+02BB-02BC, U+02C6, U+02DA, U+02DC, U+0304, U+0308, U+0329, U+2000-206F, U+2074, U+20AC, U+2122, U+2191, U+2193, U+2212, U+2215, U+FEFF, U+FFFD;
        }}

        /* cyrillic */
        @font-face {{
            font-family: 'Playfair Display';
            font-style: italic;
            font-weight: 700;
            font-display: swap;
            src: url(/fonts.gstatic.com/s/playfairdisplay/v36/nuFkD-vYSZviVYUb_rj3ij__anPXDTnohkk72xU.woff2) format('woff2');
            unicode-range: U+0301, U+0400-045F, U+0490-0491, U+04B0-04B1, U+2116;
        }}

        /* vietnamese */
        @font-face {{
            font-family: 'Playfair Display';
            font-style: italic;
            font-weight: 700;
            font-display: swap;
            src: url(/fonts.gstatic.com/s/playfairdisplay/v36/nuFkD-vYSZviVYUb_rj3ij__anPXDTnojUk72xU.woff2) format('woff2');
            unicode-range: U+0102-0103, U+0110-0111, U+0128-0129, U+0168-0169, U+01A0-01A1, U+01AF-01B0, U+0300-0301, U+0303-0304, U+0308-0309, U+0323, U+0329, U+1EA0-1EF9, U+20AB;
        }}

        /* latin-ext */
        @font-face {{
            font-family: 'Playfair Display';
            font-style: italic;
            font-weight: 700;
            font-display: swap;
            src: url(/fonts.gstatic.com/s/playfairdisplay/v36/nuFkD-vYSZviVYUb_rj3ij__anPXDTnojEk72xU.woff2) format('woff2');
            unicode-range: U+0100-02AF, U+0304, U+0308, U+0329, U+1E00-1E9F, U+1EF2-1EFF, U+2020, U+20A0-20AB, U+20AD-20CF, U+2113, U+2C60-2C7F, U+A720-A7FF;
        }}

        /* latin */
        @font-face {{
            font-family: 'Playfair Display';
            font-style: italic;
            font-weight: 700;
            font-display: swap;
            src: url(/fonts.gstatic.com/s/playfairdisplay/v36/nuFkD-vYSZviVYUb_rj3ij__anPXDTnogkk7.woff2) format('woff2');
            unicode-range: U+0000-00FF, U+0131, U+0152-0153, U+02BB-02BC, U+02C6, U+02DA, U+02DC, U+0304, U+0308, U+0329, U+2000-206F, U+2074, U+20AC, U+2122, U+2191, U+2193, U+2212, U+2215, U+FEFF, U+FFFD;
        }}

        /* cyrillic */
        @font-face {{
            font-family: 'Playfair Display';
            font-style: normal;
            font-weight: 400;
            font-display: swap;
            src: url(/fonts.gstatic.com/s/playfairdisplay/v36/nuFiD-vYSZviVYUb_rj3ij__anPXDTjYgFE_.woff2) format('woff2');
            unicode-range: U+0301, U+0400-045F, U+0490-0491, U+04B0-04B1, U+2116;
        }}

        /* vietnamese */
        @font-face {{
            font-family: 'Playfair Display';
            font-style: normal;
            font-weight: 400;
            font-display: swap;
            src: url(/fonts.gstatic.com/s/playfairdisplay/v36/nuFiD-vYSZviVYUb_rj3ij__anPXDTPYgFE_.woff2) format('woff2');
            unicode-range: U+0102-0103, U+0110-0111, U+0128-0129, U+0168-0169, U+01A0-01A1, U+01AF-01B0, U+0300-0301, U+0303-0304, U+0308-0309, U+0323, U+0329, U+1EA0-1EF9, U+20AB;
        }}

        /* latin-ext */
        @font-face {{
            font-family: 'Playfair Display';
            font-style: normal;
            font-weight: 400;
            font-display: swap;
            src: url(/fonts.gstatic.com/s/playfairdisplay/v36/nuFiD-vYSZviVYUb_rj3ij__anPXDTLYgFE_.woff2) format('woff2');
            unicode-range: U+0100-02AF, U+0304, U+0308, U+0329, U+1E00-1E9F, U+1EF2-1EFF, U+2020, U+20A0-20AB, U+20AD-20CF, U+2113, U+2C60-2C7F, U+A720-A7FF;
        }}

        /* latin */
        @font-face {{
            font-family: 'Playfair Display';
            font-style: normal;
            font-weight: 400;
            font-display: swap;
            src: url(/fonts.gstatic.com/s/playfairdisplay/v36/nuFiD-vYSZviVYUb_rj3ij__anPXDTzYgA.woff2) format('woff2');
            unicode-range: U+0000-00FF, U+0131, U+0152-0153, U+02BB-02BC, U+02C6, U+02DA, U+02DC, U+0304, U+0308, U+0329, U+2000-206F, U+2074, U+20AC, U+2122, U+2191, U+2193, U+2212, U+2215, U+FEFF, U+FFFD;
        }}

        /* cyrillic */
        @font-face {{
            font-family: 'Playfair Display';
            font-style: normal;
            font-weight: 700;
            font-display: swap;
            src: url(/fonts.gstatic.com/s/playfairdisplay/v36/nuFiD-vYSZviVYUb_rj3ij__anPXDTjYgFE_.woff2) format('woff2');
            unicode-range: U+0301, U+0400-045F, U+0490-0491, U+04B0-04B1, U+2116;
        }}

        /* vietnamese */
        @font-face {{
            font-family: 'Playfair Display';
            font-style: normal;
            font-weight: 700;
            font-display: swap;
            src: url(/fonts.gstatic.com/s/playfairdisplay/v36/nuFiD-vYSZviVYUb_rj3ij__anPXDTPYgFE_.woff2) format('woff2');
            unicode-range: U+0102-0103, U+0110-0111, U+0128-0129, U+0168-0169, U+01A0-01A1, U+01AF-01B0, U+0300-0301, U+0303-0304, U+0308-0309, U+0323, U+0329, U+1EA0-1EF9, U+20AB;
        }}

        /* latin-ext */
        @font-face {{
            font-family: 'Playfair Display';
            font-style: normal;
            font-weight: 700;
            font-display: swap;
            src: url(/fonts.gstatic.com/s/playfairdisplay/v36/nuFiD-vYSZviVYUb_rj3ij__anPXDTLYgFE_.woff2) format('woff2');
            unicode-range: U+0100-02AF, U+0304, U+0308, U+0329, U+1E00-1E9F, U+1EF2-1EFF, U+2020, U+20A0-20AB, U+20AD-20CF, U+2113, U+2C60-2C7F, U+A720-A7FF;
        }}

        /* latin */
        @font-face {{
            font-family: 'Playfair Display';
            font-style: normal;
            font-weight: 700;
            font-display: swap;
            src: url(/fonts.gstatic.com/s/playfairdisplay/v36/nuFiD-vYSZviVYUb_rj3ij__anPXDTzYgA.woff2) format('woff2');
            unicode-range: U+0000-00FF, U+0131, U+0152-0153, U+02BB-02BC, U+02C6, U+02DA, U+02DC, U+0304, U+0308, U+0329, U+2000-206F, U+2074, U+20AC, U+2122, U+2191, U+2193, U+2212, U+2215, U+FEFF, U+FFFD;
        }}
    </style>

    <style>
        html,
        body {{
            margin: 0 auto !important;
            padding: 0 !important;
            height: 100% !important;
            width: 100% !important;
            background: #f1f1f1;
        }}

        /* What it does: Stops email clients resizing small text. */
        * {{
            -ms-text-size-adjust: 100%;
            -webkit-text-size-adjust: 100%;
        }}

        /* What it does: Centers email on Android 4.4 */
        div[style*=""margin: 16px 0""] {{
            margin: 0 !important;
        }}

        /* What it does: Stops Outlook from adding extra spacing to tables. */
        table,
        td {{
            mso-table-lspace: 0pt !important;
            mso-table-rspace: 0pt !important;
        }}

        /* What it does: Fixes webkit padding issue. */
        table {{
            border-spacing: 0 !important;
            border-collapse: collapse !important;
            table-layout: fixed !important;
            margin: 0 auto !important;
        }}

        /* What it does: Uses a better rendering method when resizing images in IE. */
        img {{
            -ms-interpolation-mode: bicubic;
        }}

        /* What it does: Prevents Windows 10 Mail from underlining links despite inline CSS. Styles for underlined links should be inline. */
        a {{
            text-decoration: none;
        }}

        /* What it does: A work-around for email clients meddling in triggered links. */
        *[x-apple-data-detectors],
        /* iOS */
        .unstyle-auto-detected-links *,
        .aBn {{
            border-bottom: 0 !important;
            cursor: default !important;
            color: inherit !important;
            text-decoration: none !important;
            font-size: inherit !important;
            font-family: inherit !important;
            font-weight: inherit !important;
            line-height: inherit !important;
        }}

        /* What it does: Prevents Gmail from displaying a download button on large, non-linked images. */
        .a6S {{
            display: none !important;
            opacity: 0.01 !important;
        }}

        /* What it does: Prevents Gmail from changing the text color in conversation threads. */
        .im {{
            color: inherit !important;
        }}

        /* If the above doesn't work, add a .g-img class to any image in question. */
        img.g-img+div {{
            display: none !important;
        }}

        /* What it does: Removes right gutter in Gmail iOS app: https://github.com/TedGoas/Cerberus/issues/89  */
        /* Create one of these media queries for each additional viewport size you'd like to fix */

        /* iPhone 4, 4S, 5, 5S, 5C, and 5SE */
        @media only screen and (min-device-width: 320px) and (max-device-width: 374px) {{
            u~div .email-container {{
                min-width: 320px !important;
            }}
        }}

        /* iPhone 6, 6S, 7, 8, and X */
        @media only screen and (min-device-width: 375px) and (max-device-width: 413px) {{
            u~div .email-container {{
                min-width: 375px !important;
            }}
        }}

        /* iPhone 6+, 7+, and 8+ */
        @media only screen and (min-device-width: 414px) {{
            u~div .email-container {{
                min-width: 414px !important;
            }}
        }}
    </style>


    <style>
        .primary {{
            background: #f3a333;
        }}

        .bg_white {{
            background: #ffffff;
        }}

        .bg_light {{
            background: #fafafa;
        }}

        .bg_black {{
            background: #000000;
        }}

        .bg_dark {{
            background: rgba(0, 0, 0, .8);
        }}

        .email-section {{
            padding: 2.5em;
        }}

        /*BUTTON*/
        .btn {{
            padding: 10px 15px;
        }}

        .btn.btn-primary {{
            border-radius: 30px;
            background: #f3a333;
            color: #ffffff;
        }}



        h1,
        h2,
        h3,
        h4,
        h5,
        h6 {{
            font-family: 'Playfair Display', serif;
            color: #000000;
            margin-top: 0;
        }}

        body {{
            font-family: 'Montserrat', sans-serif;
            font-weight: 400;
            font-size: 15px;
            line-height: 1.8;
            color: rgba(0, 0, 0, .4);
        }}

        a {{
            color: #f3a333;
        }}

        table {{}}

        /*LOGO*/

        .logo h1 {{
            margin: 0;
        }}

        .logo h1 a {{
            color: #000;
            font-size: 20px;
            font-weight: 700;
            text-transform: uppercase;
            font-family: 'Montserrat', sans-serif;
        }}

        /*HERO*/
        .hero {{
            position: relative;
        }}

        .hero img {{}}

        .hero .text {{
            color: rgba(255, 255, 255, .8);
        }}

        .hero .text h2 {{
            color: #ffffff;
            font-size: 30px;
            margin-bottom: 0;
        }}


        /*HEADING SECTION*/
        .heading-section {{}}

        .heading-section h2 {{
            color: #000000;
            font-size: 28px;
            margin-top: 0;
            line-height: 1.4;
        }}

        .heading-section .subheading {{
            margin-bottom: 20px !important;
            display: inline-block;
            font-size: 13px;
            text-transform: uppercase;
            letter-spacing: 2px;
            color: rgba(0, 0, 0, .4);
            position: relative;
        }}

        .heading-section .subheading::after {{
            position: absolute;
            left: 0;
            right: 0;
            bottom: -10px;
            content: '';
            width: 100%;
            height: 2px;
            background: #f3a333;
            margin: 0 auto;
        }}

        .heading-section-white {{
            color: rgba(255, 255, 255, .8);
        }}

        .heading-section-white h2 {{
            font-size: 28px;
            font-family:
                line-height: 1;
            padding-bottom: 0;
        }}

        .heading-section-white h2 {{
            color: #ffffff;
        }}

        .heading-section-white .subheading {{
            margin-bottom: 0;
            display: inline-block;
            font-size: 13px;
            text-transform: uppercase;
            letter-spacing: 2px;
            color: rgba(255, 255, 255, .4);
        }}


        .icon {{
            text-align: center;
        }}

        .icon img {{}}


        /*SERVICES*/
        .text-services {{
            padding: 10px 10px 0;
            text-align: center;
        }}

        .text-services h3 {{
            font-size: 20px;
        }}

        /*BLOG*/
        .text-services .meta {{
            text-transform: uppercase;
            font-size: 14px;
        }}

        /*TESTIMONY*/
        .text-testimony .name {{
            margin: 0;
        }}

        .text-testimony .position {{
            color: rgba(0, 0, 0, .3);

        }}


        /*VIDEO*/
        .img {{
            width: 100%;
            height: auto;
            position: relative;
        }}

        .img .icon {{
            position: absolute;
            top: 50%;
            left: 0;
            right: 0;
            bottom: 0;
            margin-top: -25px;
        }}

        .img .icon a {{
            display: block;
            width: 60px;
            position: absolute;
            top: 0;
            left: 50%;
            margin-left: -25px;
        }}



        /*COUNTER*/
        .counter-text {{
            text-align: center;
        }}

        .counter-text .num {{
            display: block;
            color: #ffffff;
            font-size: 34px;
            font-weight: 700;
        }}

        .counter-text .name {{
            display: block;
            color: rgba(255, 255, 255, .9);
            font-size: 13px;
        }}


        /*FOOTER*/

        .footer {{
            color: rgba(255, 255, 255, .5);

        }}

        .footer .heading {{
            color: #ffffff;
            font-size: 20px;
        }}

        .footer ul {{
            margin: 0;
            padding: 0;
        }}

        .footer ul li {{
            list-style: none;
            margin-bottom: 10px;
        }}

        .footer ul li a {{
            color: rgba(255, 255, 255, 1);
        }}


        @media screen and (max-width: 500px) {{

            .icon {{
                text-align: left;
            }}

            .text-services {{
                padding-left: 0;
                padding-right: 20px;
                text-align: left;
            }}

        }}
    </style>
    <meta name=""robots"" content=""noindex, follow"">
    <script nonce=""68d045a9-5da0-44ff-b565-cdc44d84305e"">try {{ (function (w, d) {{ !function (b$, ca, cb, cc) {{ b$[cb] = b$[cb] || {{}}; b$[cb].executed = []; b$.zaraz = {{ deferred: [], listeners: [] }}; b$.zaraz.q = []; b$.zaraz._f = function (cd) {{ return async function () {{ var ce = Array.prototype.slice.call(arguments); b$.zaraz.q.push({{ m: cd, a: ce }}) }} }}; for (const cf of [""track"", ""set"", ""debug""]) b$.zaraz[cf] = b$.zaraz._f(cf); b$.zaraz.init = () => {{ var cg = ca.getElementsByTagName(cc)[0], ch = ca.createElement(cc), ci = ca.getElementsByTagName(""title"")[0]; ci && (b$[cb].t = ca.getElementsByTagName(""title"")[0].text); b$[cb].x = Math.random(); b$[cb].w = b$.screen.width; b$[cb].h = b$.screen.height; b$[cb].j = b$.innerHeight; b$[cb].e = b$.innerWidth; b$[cb].l = b$.location.href; b$[cb].r = ca.referrer; b$[cb].k = b$.screen.colorDepth; b$[cb].n = ca.characterSet; b$[cb].o = (new Date).getTimezoneOffset(); if (b$.dataLayer) for (const cm of Object.entries(Object.entries(dataLayer).reduce(((cn, co) => ({{ ...cn[1], ...co[1] }})), {{}}))) zaraz.set(cm[0], cm[1], {{ scope: ""page"" }}); b$[cb].q = []; for (; b$.zaraz.q.length;) {{ const cp = b$.zaraz.q.shift(); b$[cb].q.push(cp) }} ch.defer = !0; for (const cq of [localStorage, sessionStorage]) Object.keys(cq || {{}}).filter((cs => cs.startsWith(""_zaraz_""))).forEach((cr => {{ try {{ b$[cb][""z_"" + cr.slice(7)] = JSON.parse(cq.getItem(cr)) }} catch {{ b$[cb][""z_"" + cr.slice(7)] = cq.getItem(cr) }} }})); ch.referrerPolicy = ""origin""; ch.src = ""/cdn-cgi/zaraz/s.js?z="" + btoa(encodeURIComponent(JSON.stringify(b$[cb]))); cg.parentNode.insertBefore(ch, cg) }};[""complete"", ""interactive""].includes(ca.readyState) ? zaraz.init() : b$.addEventListener(""DOMContentLoaded"", zaraz.init) }}(w, d, ""zarazData"", ""script""); }})(window, document) }} catch (err) {{
            console.error('Failed to run Cloudflare Zaraz: ', err)
            fetch('/cdn-cgi/zaraz/t', {{
                credentials: 'include',
                keepalive: true,
                method: 'GET',
            }})
        }};</script>
</head>

<body width=""100%"" style=""margin: 0; padding: 0 !important; mso-line-height-rule: exactly; "">
    <center style=""width: 100%; background-color: #f1f1f1;"">
        <div
            style=""display: none; font-size: 1px;max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden; mso-hide: all; font-family: sans-serif;"">
            &zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;
        </div>
        <div style=""max-width: 600px; margin: 0 auto;"" class=""email-container"">

            <table align=""center"" role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" width=""100%""
                style=""margin: auto;"">
                <tr>
                    <td class=""bg_white logo"" style=""padding: 1em 2.5em; text-align: center"">
                        <h1><a href=""#"">RestoBar</a></h1>
                    </td>
                </tr>
                <tr>
                    <td valign=""middle"" class=""hero""
                        style=""background-image: url(https://picsum.photos/id/1058/600/400); background-size: cover; height: 400px;"">
                        <table>
                            <tr>
                                <td>
                                    <div class=""text"" style=""padding: 0 3em; text-align: center;"">
                                        <h2>{message}</h2>
                                        <p>A small river named Duden flows by their place and supplies it with the
                                            necessary regelialia. It is a paradisematic country, in which roasted parts
                                            of sentences fly into your mouth.</p>
                                        <p><a href=""#"" class=""btn btn-primary"">Get Your Order Here!</a></p>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>            
        </div>
    </center>

</body>

</html>";
        }
    }
}
