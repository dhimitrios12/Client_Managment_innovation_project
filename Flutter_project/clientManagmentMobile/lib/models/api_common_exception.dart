class CommonException {
  final String field;
  final String message;

  CommonException(this.field, this.message);

  CommonException.fromJOSN(Map<String, dynamic> json)
      : field = json['field'],
        message = json['message'];
}
