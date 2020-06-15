import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../providers/business_events_provider.dart';
import '../widgets/scheduled_item.dart';

class UpcomingBusinessEvents extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Consumer<BusinessEvents>(
      builder: (ctx, businesEvents, previousBusinessEvents) => RefreshIndicator(
        onRefresh: businesEvents.getScheduledServiceRequests,
        child: ListView.builder(
          itemBuilder: (ctx, index) {
            return ScheduledItem(businesEvents.businessServiceRequests[index]);
          },
          itemCount: businesEvents.businessServiceRequests.length,
        ),
      ),
    );
  }
}
