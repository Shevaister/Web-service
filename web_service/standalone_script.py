import sys
import os
import django

sys.path.append("C:/projects/py/NURE_practice_2021/web_service") 
os.environ.setdefault("DJANGO_SETTINGS_MODULE", "web_service.settings")
django.setup()

from client.models import complete_photos
from django.db.models import Min
import re
import time

while True:
    time.sleep(1)
    a = [files for files in os.walk('media/buff')]
    a = a[0][2]
    if len(a) != 0:
        z = []
        for i in range(len(a)):
            z.append(re.split(r'[_.]+', a[i]))
        for i in range(len(z)):
            T = complete_photos()
            T.photo = "complete_photos/{}".format(a[i])
            T.user_id = z[i][1]
            T.number_of_humans = z[i][2]
            T.save()
            os.replace("C:/projects/py/NURE_practice_2021/web_service/media/buff/{}".format(a[i]), "C:/projects/py/NURE_practice_2021/web_service/media/complete_photos/{}".format(a[i]))


