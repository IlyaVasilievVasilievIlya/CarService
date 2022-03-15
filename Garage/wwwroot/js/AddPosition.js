$("#WorkId").selectize({
	plugins: ["remove_button"],
	valueField: "id",
	labelField: 'name',
	searchField: "name",
	placeholder: "введите текст",
	options: [],
	persist: false,
	create: false,
	closeAfterSelect: true,

	load: function (query, callback) {
		if (!query.length) {
			return callback();
		}

		$.get("/api/Work/find/" + query,
			function (data) {
				if (data.length > 0) {
					$("#WorkId option").remove();

					for (var i = 0; i < data.length; i++) {
						console.log(data[i].fullName);
						$("#WorkId").append("<option value=\"" + data[i].id + "\">" +
							data[i].name + "</option>");
					}

					callback(data);
				}
			}, "json");
	},

	onChange: function (value) {
		if (!value) {
			return;
		}
		$.get("/api/Work/" + value,
			function (data) {
				console.log(data);
				$.get("/api/WorkType/getMechanics/" + data.workType.id,
					function (data) {
						if (data.length > 0) {
							for (var i = 0; i < data.length; i++) {
								$("#MechanicId").append("<option value=\"" + data[i].id + "\">" +
									data[i].name + "</option>");
							}
                        }
					}, "json");
			}, "json");
	},

	onClear: function () {
		$("#MechanicId option").remove();
    }
});
