

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head><title>
	Orders
</title>
    <style>
        form{
            width: fit-content;
            margin:0 auto;
        }
        table{
            border-spacing:0;
        }
        th,tr,td{
            border:solid 1px black;
            padding:5px;
        }
    </style>
</head>
<body>
    <h3 style="text-align:center;">Orders</h3>
    <form method="post" action="./Orderform.aspx" id="Form">
<div class="aspNetHidden">
<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="jVNDLK4l5PNC7A7P51soJAHhRZrpuXxRCFlB+UiGz6LlP/Yq6O5llSWj5AvrYB+4Xsbm+wqjEZxOtvwONLQGkLuyc8vE2AZx/iqKWJBF0zI=" />
</div>

<div class="aspNetHidden">

	<input type="hidden" name="__VIEWSTATEGENERATOR" id="__VIEWSTATEGENERATOR" value="B3D6352B" />
	<input type="hidden" name="__EVENTVALIDATION" id="__EVENTVALIDATION" value="35EbmNPq6pUISUqiUo3Ng5BFGadRHzwc2ZvYwuiHmeA0pdUtei30xe0lexpiodLAmbwRZY3ESXMe/ss4zLXBZx8iTo/KR32XqjJGKjX0hNNQ+hYiOqbImd3mTFBk9ofIcEfq93PgfyLeMZ097d5FIyN1xOLs6Cln4IvRZRIaIIa3+e9LCrAv/BJVKjxoP2W/gojhTnc+p2S5+/LZE/AS+U0igzDKS6igYMreLfQq1HsxL+rNIZZfW/MMK+RYsI8Zq8+3wumqR+p20bzzKNEXN9nS9NycB2pRaNrM6SGSNf48e4v66hogsYjUBG02SJZCwkJ0PoDejgPuuqJZWM7WFIK4DLIv73TfR/ShR7BRUkDVjKXRLnfxWMk8KUCUjBuQZekTTbOwG+YNboRznHsb8BKIOzXM6ocWPQ6Fbh7YnkCwSKpoWQGjNXpm9ehOHy8WfbetOetDKDDZLpS+EJj6Z7HEvvukoTTOtsQu/rzd9z4VxEtVa1C3o/wAnAVM+6OEPgj0tROrMaMrfHyKQ5lSdlY92gH0XTLMf/3clq1VcWw=" />
</div>
      <table>
          <tr><th>Items</th><th>Descprition</th><th>Price</th><th>Qty</th></tr>
          <tr><td>Jacket</td><td>LightWeight and Stylish</td><td>$30.99</td><td>
              <select name="Jacket" id="Jacket">
	<option selected="selected" value="null"> </option>
	<option value="1">1</option>
	<option value="2">2</option>
	<option value="3">3</option>

</select>
          </td></tr>
          <tr><td>Jeans</td><td>Slim Straight</td><td>$20.99</td><td>
              <select name="Jeans" id="Jeans">
	<option selected="selected" value="null"> </option>
	<option value="1">1</option>
	<option value="2">2</option>
	<option value="3">3</option>

</select>
          </td></tr>
          <tr><td>Socks</td><td>Comfortable,ankle cut</td><td>$7.00</td><td>
              <select name="Socks" id="Socks">
	<option selected="selected" value="null"> </option>
	<option value="1">1</option>
	<option value="2">2</option>
	<option value="3">3</option>

</select>
          </td></tr>
          <tr><td>Bracelet</td><td>Everyday Accessory</td><td>$5.00</td><td>
              <select name="Bracelet" id="Bracelet">
	<option selected="selected" value="null"> </option>
	<option value="1">1</option>
	<option value="2">2</option>
	<option value="3">3</option>

</select>
          </td></tr>
          <tr><td>Polo Shirt</td><td>Comfortable,ankle cut</td><td>$5.00</td><td>
              <select name="Polo" id="Polo">
	<option selected="selected" value="null"> </option>
	<option value="1">1</option>
	<option value="2">2</option>
	<option value="3">3</option>

</select>
          </td></tr>
      </table>
        <input type="submit" name="Submit" value="Submit" id="Submit" />
    </form>
</body>
</html>
