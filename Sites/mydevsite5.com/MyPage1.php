<?php
session_name(‘Private’);
session_start();
$private_id = session_id();
$user = get_current_user();
$_SESSION[‘user’] = $user;
$_SESSION[‘password’] = “Super_Secret”;
session_write_close();
?>
<html>
<body>
<head>
<title>Session Test Page 1</title>
</head>
<p>Checking the session array:</p>
<p>…session id is <?=$private_id?></p>
<p>…user is <?=$_SESSION[‘user’]?></p>
<p>…password is <?=$_SESSION[‘password’]?></p>
<p>OK</p>
<a HREF=”MyPage2.php?id=<?=$private_id?>”>Page 2</a> </body>
</html>