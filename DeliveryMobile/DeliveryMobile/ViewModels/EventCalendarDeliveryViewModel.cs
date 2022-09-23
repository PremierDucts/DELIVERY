﻿using DeliveryMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XCalendar.Core.Enums;
using XCalendar.Core.Models;

namespace DeliveryMobile.ViewModels
{
    public class EventCalendarDeliveryViewModel : BaseViewModel
    {
        #region Properties
        public Calendar<EventDay> EventCalendar { get; set; } = new Calendar<EventDay>()
        {
            SelectedDates = new ObservableRangeCollection<DateTime>(),
            SelectionAction = SelectionAction.Replace,
            SelectionType = SelectionType.Single
        };
        public static readonly Random Random = new Random();
        public List<Color> Colors { get; } = new List<Color>() { Color.Red, Color.Orange, Color.Yellow, Color.FromHex("#00A000"), Color.Blue, Color.FromHex("#8010E0") };
        public List<Color> ColorsOnDay { get; } = new List<Color>() { Color.Red, Color.Orange, Color.Blue, Color.Brown, Color.Blue, Color.CadetBlue, Color.DarkMagenta, Color.Aqua, Color.Coral, Color.YellowGreen, Color.SeaGreen, Color.DeepPink };
        public ObservableRangeCollection<Event> Events { get; } = new ObservableRangeCollection<Event>()
        {
            new Event()
                {
                    JobNo = $"#Q10001",
                    DeliveryInfo = new DeliveryInfo()
                        {
                            PicAddress = $"Ha Noi",
                            PicCompanyName = $"XYZ",
                            PicContactName = $"Phat Tran",
                            PicEmailAddress = $"phat@gmail.com",
                            PicNotes = $"Note",
                            PicPhone = $"0123456789",
                            TimeDelivery = DateTime.Now,
                            FilePath = "QLD/AGCOOMBS/Gatton.S.2",
                            Destinations = new ObservableCollection<Destination>()
                            {
                                new Destination()
                                {
                                    DesAddress = $"HCM",
                                    DesCompanyName = $"Premier Ducts",
                                    DesContactName = $"Huu Quy",
                                    DesEmailAddress = $"huuquy1211@gmail.com",
                                    DesNotes = $"Note",
                                    DesPhone = $"0933323622"
                                }
                            },
                            ListStorage = new ObservableCollection<Storage>()
                                {
                                    new Storage()
                                    {
                                        Name = $"Name 1",
                                        Amount = 30,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    },
                                    new Storage()
                                    {
                                        Name = $"Name 2",
                                        Amount = 2,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    }
                                }
                        }
            },
            new Event()
                {
                    JobNo = $"#Q10002",
                    DeliveryInfo = new DeliveryInfo()
                        {
                              FilePath = "QLD/AGCOOMBS/Gatton.S.2",

                            PicAddress = $"Ha Noi",
                            PicCompanyName = $"XYZ",
                            PicContactName = $"Phat Tran",
                            PicEmailAddress = $"phat@gmail.com",
                            PicNotes = $"Note",
                            PicPhone = $"0123456789",
                             TimeDelivery = DateTime.Now,

                            Destinations = new ObservableCollection<Destination>()
                            {
                                new Destination()
                                {
                                    DesAddress = $"HCM",
                                    DesCompanyName = $"Premier Ducts",
                                    DesContactName = $"Huu Quy",
                                    DesEmailAddress = $"huuquy1211@gmail.com",
                                    DesNotes = $"Note",
                                    DesPhone = $"0933323622"
                                }
                            },
                            ListStorage = new ObservableCollection<Storage>()
                                {
                                    new Storage()
                                    {
                                        Name = $"Name 1",
                                        Amount = 30,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    },
                                    new Storage()
                                    {
                                        Name = $"Name 2",
                                        Amount = 2,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    }
                                }
                        }
            },
            new Event()
                {
                    JobNo = $"#Q10003",
                    DeliveryInfo = new DeliveryInfo()
                        {
                            FilePath = "QLD/AGCOOMBS/Gatton.S.2",

                            PicAddress = $"Ha Noi",
                            PicCompanyName = $"XYZ",
                            PicContactName = $"Phat Tran",
                            PicEmailAddress = $"phat@gmail.com",
                            PicNotes = $"Note",
                            PicPhone = $"0123456789",
                             TimeDelivery = DateTime.Now,

                            Destinations = new ObservableCollection<Destination>()
                            {
                                new Destination()
                                {
                                    DesAddress = $"HCM",
                                    DesCompanyName = $"Premier Ducts",
                                    DesContactName = $"Huu Quy",
                                    DesEmailAddress = $"huuquy1211@gmail.com",
                                    DesNotes = $"Note",
                                    DesPhone = $"0933323622"
                                }
                            },
                            ListStorage = new ObservableCollection<Storage>()
                                {
                                    new Storage()
                                    {
                                        Name = $"Name 1",
                                        Amount = 30,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    },
                                    new Storage()
                                    {
                                        Name = $"Name 2",
                                        Amount = 2,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    }
                                }
                        }
            },
            new Event()
                {
                    JobNo = $"#Q10004",
                    DeliveryInfo= new DeliveryInfo()
                        {
                            FilePath = "QLD/AGCOOMBS/Gatton.S.2",
                            Destinations = new ObservableCollection<Destination>()
                            {
                                new Destination()
                                {
                                    DesAddress = $"HCM",
                                    DesCompanyName = $"Premier Ducts",
                                    DesContactName = $"Huu Quy",
                                    DesEmailAddress = $"huuquy1211@gmail.com",
                                    DesNotes = $"Note",
                                    DesPhone = $"0933323622"
                                }
                            },

                            PicAddress = $"Ha Noi",
                            PicCompanyName = $"XYZ",
                            PicContactName = $"Phat Tran",
                            PicEmailAddress = $"phat@gmail.com",
                            PicNotes = $"Note",
                            PicPhone = $"0123456789",
                             TimeDelivery = DateTime.Now,

                            ListStorage = new ObservableCollection<Storage>()
                                {
                                    new Storage()
                                    {
                                        Name = $"Name 1",
                                        Amount = 30,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    },
                                    new Storage()
                                    {
                                        Name = $"Name 2",
                                        Amount = 2,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    }
                                }
                        }
            },
            new Event()
                {
                    JobNo = $"#Q10005",
                    DeliveryInfo = new DeliveryInfo()
                        {
                            FilePath = "QLD/AGCOOMBS/Gatton.S.2",
                           Destinations = new ObservableCollection<Destination>()
                            {
                                new Destination()
                                {
                                    DesAddress = $"HCM",
                                    DesCompanyName = $"Premier Ducts",
                                    DesContactName = $"Huu Quy",
                                    DesEmailAddress = $"huuquy1211@gmail.com",
                                    DesNotes = $"Note",
                                    DesPhone = $"0933323622"
                                }
                            },
                            PicAddress = $"Ha Noi",
                            PicCompanyName = $"XYZ",
                            PicContactName = $"Phat Tran",
                            PicEmailAddress = $"phat@gmail.com",
                            PicNotes = $"Note",
                            PicPhone = $"0123456789",
                             TimeDelivery = DateTime.Now,

                            ListStorage = new ObservableCollection<Storage>()
                                {
                                    new Storage()
                                    {
                                        Name = $"Name 1",
                                        Amount = 30,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    },
                                    new Storage()
                                    {
                                        Name = $"Name 2",
                                        Amount = 2,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    }
                                }
                        }
            },
            new Event()
                {
                    JobNo = $"#Q10006",
                    DeliveryInfo =new DeliveryInfo()
                        {
                            FilePath = "QLD/AGCOOMBS/Gatton.S.2",
                           Destinations = new ObservableCollection<Destination>()
                            {
                                new Destination()
                                {
                                    DesAddress = $"HCM",
                                    DesCompanyName = $"Premier Ducts",
                                    DesContactName = $"Huu Quy",
                                    DesEmailAddress = $"huuquy1211@gmail.com",
                                    DesNotes = $"Note",
                                    DesPhone = $"0933323622"
                                }
                            },
                            PicAddress = $"Ha Noi",
                            PicCompanyName = $"XYZ",
                            PicContactName = $"Phat Tran",
                            PicEmailAddress = $"phat@gmail.com",
                            PicNotes = $"Note",
                            PicPhone = $"0123456789",
                             TimeDelivery = DateTime.Now,

                            ListStorage = new ObservableCollection<Storage>()
                                {
                                    new Storage()
                                    {
                                        Name = $"Name 1",
                                        Amount = 30,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    },
                                    new Storage()
                                    {
                                        Name = $"Name 2",
                                        Amount = 2,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    }
                                }
                        }
            },
            new Event()
                {
                    JobNo = $"#Q10007",
                    DeliveryInfo = new DeliveryInfo()
                        {
                            FilePath = "QLD/AGCOOMBS/Gatton.S.2",
                           Destinations = new ObservableCollection<Destination>()
                            {
                                new Destination()
                                {
                                    DesAddress = $"HCM",
                                    DesCompanyName = $"Premier Ducts",
                                    DesContactName = $"Huu Quy",
                                    DesEmailAddress = $"huuquy1211@gmail.com",
                                    DesNotes = $"Note",
                                    DesPhone = $"0933323622"
                                }
                            },
                            PicAddress = $"Ha Noi",
                            PicCompanyName = $"XYZ",
                            PicContactName = $"Phat Tran",
                            PicEmailAddress = $"phat@gmail.com",
                            PicNotes = $"Note",
                            PicPhone = $"0123456789",
                             TimeDelivery = DateTime.Now,

                            ListStorage = new ObservableCollection<Storage>()
                                {
                                    new Storage()
                                    {
                                        Name = $"Name 1",
                                        Amount = 30,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    },
                                    new Storage()
                                    {
                                        Name = $"Name 2",
                                        Amount = 2,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    }
                                }
                        }
            },
            new Event()
                {
                    JobNo = $"#Q10008",
                    DeliveryInfo =new DeliveryInfo()
                        {
                            FilePath = "QLD/AGCOOMBS/Gatton.S.2",
                          Destinations = new ObservableCollection<Destination>()
                            {
                                new Destination()
                                {
                                    DesAddress = $"HCM",
                                    DesCompanyName = $"Premier Ducts",
                                    DesContactName = $"Huu Quy",
                                    DesEmailAddress = $"huuquy1211@gmail.com",
                                    DesNotes = $"Note",
                                    DesPhone = $"0933323622"
                                }
                            },
                            PicAddress = $"Ha Noi",
                            PicCompanyName = $"XYZ",
                            PicContactName = $"Phat Tran",
                            PicEmailAddress = $"phat@gmail.com",
                            PicNotes = $"Note",
                            PicPhone = $"0123456789",
                             TimeDelivery = DateTime.Now,

                            ListStorage = new ObservableCollection<Storage>()
                                {
                                    new Storage()
                                    {
                                        Name = $"Name 1",
                                        Amount = 30,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    },
                                    new Storage()
                                    {
                                        Name = $"Name 2",
                                        Amount = 2,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    }
                                }
                        }
            },
            new Event()
                {
                    JobNo = $"#Q10009",
                    DeliveryInfo =new DeliveryInfo()
                        {
                            FilePath = "QLD/AGCOOMBS/Gatton.S.2",
                           Destinations = new ObservableCollection<Destination>()
                            {
                                new Destination()
                                {
                                    DesAddress = $"HCM",
                                    DesCompanyName = $"Premier Ducts",
                                    DesContactName = $"Huu Quy",
                                    DesEmailAddress = $"huuquy1211@gmail.com",
                                    DesNotes = $"Note",
                                    DesPhone = $"0933323622"
                                }
                            },
                            PicAddress = $"Ha Noi",
                            PicCompanyName = $"XYZ",
                            PicContactName = $"Phat Tran",
                            PicEmailAddress = $"phat@gmail.com",
                            PicNotes = $"Note",
                            PicPhone = $"0123456789",
                             TimeDelivery = DateTime.Now,

                            ListStorage = new ObservableCollection<Storage>()
                                {
                                    new Storage()
                                    {
                                        Name = $"Name 1",
                                        Amount = 30,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    },
                                    new Storage()
                                    {
                                        Name = $"Name 2",
                                        Amount = 2,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    }
                                }
                        }
            },
            new Event()
                {
                    JobNo = $"#Q100010",
                    DeliveryInfo =new DeliveryInfo()
                        {
                            FilePath = "QLD/AGCOOMBS/Gatton.S.2",
                           Destinations = new ObservableCollection<Destination>()
                            {
                                new Destination()
                                {
                                    DesAddress = $"HCM",
                                    DesCompanyName = $"Premier Ducts",
                                    DesContactName = $"Huu Quy",
                                    DesEmailAddress = $"huuquy1211@gmail.com",
                                    DesNotes = $"Note",
                                    DesPhone = $"0933323622"
                                }
                            },
                            PicAddress = $"Ha Noi",
                            PicCompanyName = $"XYZ",
                            PicContactName = $"Phat Tran",
                            PicEmailAddress = $"phat@gmail.com",
                            PicNotes = $"Note",
                            PicPhone = $"0123456789",
                             TimeDelivery = DateTime.Now,

                            ListStorage = new ObservableCollection<Storage>()
                                {
                                    new Storage()
                                    {
                                        Name = $"Name 1",
                                        Amount = 30,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    },
                                    new Storage()
                                    {
                                        Name = $"Name 2",
                                        Amount = 2,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    }
                                }
                        }
            },
            new Event()
                {
                    JobNo = $"#Q100011",
                    DeliveryInfo=new DeliveryInfo()
                        {
                            FilePath = "QLD/AGCOOMBS/Gatton.S.2",
                           Destinations = new ObservableCollection<Destination>()
                            {
                                new Destination()
                                {
                                    DesAddress = $"HCM",
                                    DesCompanyName = $"Premier Ducts",
                                    DesContactName = $"Huu Quy",
                                    DesEmailAddress = $"huuquy1211@gmail.com",
                                    DesNotes = $"Note",
                                    DesPhone = $"0933323622"
                                }
                            },
                            PicAddress = $"Ha Noi",
                            PicCompanyName = $"XYZ",
                            PicContactName = $"Phat Tran",
                            PicEmailAddress = $"phat@gmail.com",
                            PicNotes = $"Note",
                            PicPhone = $"0123456789",
                             TimeDelivery = DateTime.Now,

                            ListStorage = new ObservableCollection<Storage>()
                                {
                                    new Storage()
                                    {
                                        Name = $"Name 1",
                                        Amount = 30,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    },
                                    new Storage()
                                    {
                                        Name = $"Name 2",
                                        Amount = 2,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    }
                                }
                        }

            },
            new Event()
                {
                    JobNo = $"#Q100012",
                    DeliveryInfo =new DeliveryInfo()
                        {
                            FilePath = "QLD/AGCOOMBS/Gatton.S.2",
                          Destinations = new ObservableCollection<Destination>()
                            {
                                new Destination()
                                {
                                    DesAddress = $"HCM",
                                    DesCompanyName = $"Premier Ducts",
                                    DesContactName = $"Huu Quy",
                                    DesEmailAddress = $"huuquy1211@gmail.com",
                                    DesNotes = $"Note",
                                    DesPhone = $"0933323622"
                                }
                            },
                            PicAddress = $"Ha Noi",
                            PicCompanyName = $"XYZ",
                            PicContactName = $"Phat Tran",
                            PicEmailAddress = $"phat@gmail.com",
                            PicNotes = $"Note",
                            PicPhone = $"0123456789",
                             TimeDelivery = DateTime.Now,

                            ListStorage = new ObservableCollection<Storage>()
                                {
                                    new Storage()
                                    {
                                        Name = $"Name 1",
                                        Amount = 30,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    },
                                    new Storage()
                                    {
                                        Name = $"Name 2",
                                        Amount = 2,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    }
                                }
                        }
            },
            new Event()
                {
                    JobNo = $"#Q100013",
                    DeliveryInfo = new DeliveryInfo()
                        {
                            FilePath = "QLD/AGCOOMBS/Gatton.S.2",
                           Destinations = new ObservableCollection<Destination>()
                            {
                                new Destination()
                                {
                                    DesAddress = $"HCM",
                                    DesCompanyName = $"Premier Ducts",
                                    DesContactName = $"Huu Quy",
                                    DesEmailAddress = $"huuquy1211@gmail.com",
                                    DesNotes = $"Note",
                                    DesPhone = $"0933323622"
                                }
                            },
                            PicAddress = $"Ha Noi",
                            PicCompanyName = $"XYZ",
                            PicContactName = $"Phat Tran",
                            PicEmailAddress = $"phat@gmail.com",
                            PicNotes = $"Note",
                            PicPhone = $"0123456789",
                             TimeDelivery = DateTime.Now,

                            ListStorage = new ObservableCollection<Storage>()
                                {
                                    new Storage()
                                    {
                                        Name = $"Name 1",
                                        Amount = 30,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    },
                                    new Storage()
                                    {
                                        Name = $"Name 2",
                                        Amount = 2,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    }
                                }
                        }
            },
            new Event()
                {
                    JobNo = $"#Q100014",
                    DeliveryInfo =new DeliveryInfo()
                        {
                            FilePath = "QLD/AGCOOMBS/Gatton.S.2",
                          Destinations = new ObservableCollection<Destination>()
                            {
                                new Destination()
                                {
                                    DesAddress = $"HCM",
                                    DesCompanyName = $"Premier Ducts",
                                    DesContactName = $"Huu Quy",
                                    DesEmailAddress = $"huuquy1211@gmail.com",
                                    DesNotes = $"Note",
                                    DesPhone = $"0933323622"
                                }
                            },
                            PicAddress = $"Ha Noi",
                            PicCompanyName = $"XYZ",
                            PicContactName = $"Phat Tran",
                            PicEmailAddress = $"phat@gmail.com",
                            PicNotes = $"Note",
                            PicPhone = $"0123456789",
                             TimeDelivery = DateTime.Now,

                            ListStorage = new ObservableCollection<Storage>()
                                {
                                    new Storage()
                                    {
                                        Name = $"Name 1",
                                        Amount = 30,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    },
                                    new Storage()
                                    {
                                        Name = $"Name 2",
                                        Amount = 2,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    }
                                }
                        }
            },
            new Event()
                {
                    JobNo = $"#Q100015",
                    DeliveryInfo =new DeliveryInfo()
                        {
                            FilePath = "QLD/AGCOOMBS/Gatton.S.2",
                            PicAddress = $"Ha Noi",
                            PicCompanyName = $"XYZ",
                            PicContactName = $"Phat Tran",
                            PicEmailAddress = $"phat@gmail.com",
                            PicNotes = $"Note",
                            PicPhone = $"0123456789",
                             TimeDelivery = DateTime.Now,

                            Destinations = new ObservableCollection<Destination>()
                            {
                                new Destination()
                                {
                                    DesAddress = $"HCM",
                                    DesCompanyName = $"Premier Ducts",
                                    DesContactName = $"Huu Quy",
                                    DesEmailAddress = $"huuquy1211@gmail.com",
                                    DesNotes = $"Note",
                                    DesPhone = $"0933323622"
                                }
                            },
                            ListStorage = new ObservableCollection<Storage>()
                                {
                                    new Storage()
                                    {
                                        Name = $"Name 1",
                                        Amount = 30,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    },
                                    new Storage()
                                    {
                                        Name = $"Name 2",
                                        Amount = 2,
                                        ListStorageDetail = new ObservableCollection<StorageDetail>()
                                        {
                                            new StorageDetail()
                                            {
                                                jobno = $"QB 1",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 1",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 2",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 2",
                                            },

                                            new StorageDetail()
                                            {
                                                jobno = $"QB 3",
                                                filename =  $"QLD/AGCOOMB...ton S.2/RE 8 - 1st Floor 3",
                                            }
                                        }
                                    }
                                }
                        }
            },
        };
        public ObservableRangeCollection<Event> SelectedEvents { get; } = new ObservableRangeCollection<Event>();

        public DateTime CurrentDay => DateTime.Now;

        private bool _isVisibleCalendar = true;
        public bool IsVisibleCalendar
        {
            get { return _isVisibleCalendar; }
            set
            {
                _isVisibleCalendar = value;
                OnPropertyChanged("IsVisibleCalendar");
            }
        }

        private bool _isRunningAnimation = false;
        public bool IsRunningAnimation
        {
            get { return _isRunningAnimation; }
            set
            {
                _isRunningAnimation = value;
                OnPropertyChanged("IsRunningAnimation");
            }
        }
        #endregion

        #region Commands
        public ICommand NavigateCalendarCommand { get; set; }
        public ICommand ChangeDateSelectionCommand { get; set; }
        #endregion

        #region Constructors
        public EventCalendarDeliveryViewModel()
        {
            NavigateCalendarCommand = new Command<int>(NavigateCalendar);
            ChangeDateSelectionCommand = new Command<DateTime>(ChangeDateSelection);

            foreach (Event Event in Events)
            {
                Event.TimeDelivery = DateTime.Today.AddDays(Random.Next(-20, 21)).AddSeconds(Random.Next(86400));
                Event.Color = Colors[Random.Next(6)];
            }

            EventCalendar.SelectedDates.CollectionChanged += SelectedDates_CollectionChanged;
            EventCalendar.DaysUpdated += EventCalendar_DaysUpdated;
            var index = 0;
            foreach (var Day in EventCalendar.Days)
            {
                var listEvents = Events.Where(x => x.TimeDelivery.Date == Day.DateTime.Date);
                var color = ColorsOnDay[Random.Next(12)];
                foreach (var ev in listEvents)
                    ev.CurrentDayColor = color;
                Day.Events.ReplaceRange(listEvents);
                index++;
            }
        }

        private void SelectedDates_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SelectedEvents.ReplaceRange(Events.Where(x => EventCalendar.SelectedDates.Any(y => x.TimeDelivery.Date == y.Date)).OrderBy(x => x.TimeDelivery).ThenBy(z => z.TimeDelivery.TimeOfDay));
        }
        #endregion

        #region Methods
        private void EventCalendar_DaysUpdated(object sender, EventArgs e)
        {
            foreach (var Day in EventCalendar.Days)
            {
                Day.Events.ReplaceRange(Events.Where(x => x.TimeDelivery.Date == Day.DateTime.Date));
            }
        }
        public void NavigateCalendar(int Amount)
        {
            EventCalendar?.NavigateCalendar(Amount);
        }
        public void ChangeDateSelection(DateTime DateTime)
        {
            EventCalendar?.ChangeDateSelection(DateTime);
        }
        #endregion
    }
}
