$("#ClientCar_ClientId").selectize({
	plugins: ["remove_button"],
	valueField: "id",
	labelField: 'fullName',
	searchField: "fullName",
	placeholder: "Введите ФИО клиента",
	options: [],
	persist: false,
	create: false,
	closeAfterSelect: true,

	load: function (query, callback) {
		if (!query.length) {
			return callback();
		}

		$.get("/api/Client/find/" + query,
			function (data) {
				if (data.length > 0) {
					$("#ClientCar_ClientId option").remove();

					for (var i = 0; i < data.length; i++) {
						$("#ClientCar_ClientId").append("<option value=\"" + data[i].id + "\">" +
							data[i].fullName + "</option>");
					}

					callback(data);
				}
			}, "json");
	},

	onChange: function (value) {
		if (!value) {
			return;
		}
		console.log(value);
		$.get("/api/Client/findCar/" + value,
			function (data) {
				$("#ClientCar_CarId option").remove();
				if (data.length > 0) {
					for (var i = 0; i < data.length; i++) {
						$("#ClientCar_CarId").append("<option value=\"" + data[i].id + "\">" +
							data[i].model.name + " " + data[i].manufactureYear +  "</option>");
					}
				}
			}, "json");
	},

	onClear: function () {
		$("#ClientCar_CarId option").remove();
    }
});

