Client side validation

<details>
	<summary>View.cshtml</summary>
	
	```csharp

		@using (Html.BeginForm(actionName: "AddCustomer", controllerName: "Home", method: FormMethod.Post))
		    {
			<div class="row">
			    <div class="col-lg-2">
				@Html.LabelFor(m => m.customer.CustomerName)
			    </div>
			    <div class="col-lg-2">
				@Html.TextBoxFor(m => m.customer.CustomerName, "", new { id = "CustomerName" })
			    </div>
			</div>
			<div class="row">
			    <div class="col-lg-4">
				@Html.ValidationMessageFor(m => m.customer.CustomerName, "", new { @class = "text-danger" })
			    </div>
			</div>
			(...)
		    }

	```
</details>

<details>
	<summary>_Layout.cshtml<summary>
		
	```csharp
		@Scripts.Render("~/bundles/jquery")
    		@Scripts.Render("~/bundles/jqueryval")
	```
		
</details>
		
<details>
	<summary>BundleConfig.cs</summary>
	
	```csharp
	    public class BundleConfig
	    {
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
		    bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
				"~/Scripts/jquery-{version}.js"));

		    bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
				"~/Scripts/jquery.validate*"));
	```
	
</details>

<picture> 
 <img alt="YOUR-ALT-TEXT" src=".\FormShowingValidationMessage.png">
</picture>
