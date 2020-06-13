import 'package:dio/dio.dart';

class CustomDioClient {
  final Dio client;

  CustomDioClient(this.client) {
    client.options.baseUrl = 'http://192.168.1.239:8080/api';
    client.options.connectTimeout = 5000;
    client.options.receiveTimeout = 10000;
  }
}
