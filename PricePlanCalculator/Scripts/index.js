$(function () {
	$('form').submit(function () {
			$.ajax({
				url: this.action,
				type: this.method,
				data: $(this).serialize(),
				success: function (result) {
					$('#result').html(result);
				}
			});
		return false;
	});
});