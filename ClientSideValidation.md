Client side validation

## View.cshtml

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


## Layout.cshtml

```csharp
	
	@Scripts.Render("~/bundles/jquery")
	@Scripts.Render("~/bundles/jqueryval")
	
```
		
## BundleConfig.cs

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

<picture> 
 <img alt="YOUR-ALT-TEXT" src=".\FormShowingValidationMessage.png">
</picture>
