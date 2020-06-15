import 'package:flutter/material.dart';
import 'package:dio/dio.dart';

import '../models/helpers/custom_dio_client.dart';
import '../models/service_request_model.dart';

class BusinessEvents with ChangeNotifier {
  List<ServiceRequest> _businessServiceRequests = [];

  // Get scheduled service requests for business
  Future<void> getScheduledServiceRequests() async {
    const String path = "//Service/BusinessSchedule";
    try {
      final Response response = await CustomDioClient().dio.get(path);
      _businessServiceRequests = [];
      (response.data as List<dynamic>).forEach(
        (element) {
          _businessServiceRequests.add(ServiceRequest.fromJson(element));
        },
      );
      notifyListeners();
    } on DioError catch (error) {
      throw error;
    }
  }

  List<ServiceRequest> get businessServiceRequests {
    return [..._businessServiceRequests];
  }
}
