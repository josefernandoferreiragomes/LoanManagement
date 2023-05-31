## Client side validation

### How to get it to work...

### AddCustomer.cshtml

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


### Layout.cshtml

```csharp
	
	@Scripts.Render("~/bundles/jquery")
	@Scripts.Render("~/bundles/jqueryval")
	
```
		
### BundleConfig.cs

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
### Web.config

```xml
	<configuration>
	  <appSettings>
	    <!-- ... -->
	    <add key="ClientValidationEnabled" value="true" />
	    <add key="UnobtrusiveJavaScriptEnabled" value="true" />
	    <!-- ... -->
	  </appSettings>
```
### If we start the application and browse to AddCustomer Page
<picture> 
 <img alt="FormShowingValidationMessage" src=".\FormShowingValidationMessage.png">
</picture>

We can submit the form without filling any of the fields and it will show the validation messages

### CustomerController.cs
It will not stop at the breakpoint, because client-side validation is active and well configured
<picture>
	<img alt="CustomerControllerNoDebug" src=".\CustomerControllerNoDebug.png">
</picture>


## If ClientValidation is disabled on Web.config, or any missconfiguration, it will stop at the breakpoint on CustomerController

### CustomerController.cs

<picture>
	<img alt="CustomerControllerDebug" src=".\CustomerControllerDebug.png">
</picture>

And it will be the server-side code to enforce the validations instead of the client-side code
