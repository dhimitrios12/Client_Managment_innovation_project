import 'dart:io';

import 'package:dio/dio.dart';

class CustomDioClient {
  static const BASE_URL = "http://192.168.1.239:8080/api";
  static BaseOptions options = BaseOptions(
    baseUrl: BASE_URL,
    connectTimeout: 10000,
    receiveTimeout: 10000,
  );

  static final CustomDioClient _instance =
      CustomDioClient._privateConstructor();
  Dio _dio = Dio(options);

  Dio get dio {
    return _dio;
  }

  CustomDioClient._privateConstructor();

  factory CustomDioClient() {
    return _instance;
  }

  void addAuthenticationHeader(String authToken) {
    _dio.options.headers[HttpHeaders.authorizationHeader] = "Bearer $authToken";
  }
}
