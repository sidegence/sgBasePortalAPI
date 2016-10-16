using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

using sgBasePortalAPI.Helpers;

namespace sgBasePortalAPI
{
    public enum AnnouncementSortColumn
    {
        id,
        type,
        basePrice,
        contractDesignation,
        drPublicationDate,
        proposalDeadline,
        contractingEntity,
    }

    public enum AnnouncementFilterColumn
    {
        emissora,
        desdedatapublicacao,
        atedatapublicacao,
        desdeprecobase,
        ateprecobase,
    }

    [Serializable]
    public class Announcement
    {
        public int id { get; set; }
        public string type { get; set; }
        public float basePrice { get; set; }
        public string contractDesignation { get; set; }
        public DateTime? drPublicationDate { get; set; }
        public DateTime? proposalDeadline { get; set; }
        public string contractingEntity { get; set; }

        public string reference { get; set; }
        public string announcementNumber { get; set; }
        public string contractType { get; set; }
        public List<Entity> contractingEntities { get; set; }
        public string cpvs { get; set; }
        public string dreNumber { get; set; }
        public string dreSeries { get; set; }
        public string modelType { get; set; }
        public int contractsCount { get; set; }

        public string ToLongString()
        {
            return
                string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}",
                    id,
                    type,
                    basePrice,
                    contractDesignation,
                    drPublicationDate,
                    proposalDeadline,
                    contractingEntity,
                    reference,
                    announcementNumber,
                    contractType,
                    contractingEntities == null ? 0 : contractingEntities.Count,
                    cpvs,
                    dreNumber,
                    dreSeries,
                    modelType,
                    contractsCount
                );
        }
    }

    [Serializable]
    internal class AnnouncementJson
    {
        public int id { get; set; }
        public string type { get; set; }
        public string basePrice { get; set; }
        public string contractDesignation { get; set; }
        public string drPublicationDate { get; set; }
        public string proposalDeadline { get; set; }
        public string contractingEntity { get; set; }

        public string reference { get; set; }
        public string announcementNumber { get; set; }
        public string contractType { get; set; }
        public List<Entity> contractingEntities { get; set; }
        public string cpvs { get; set; }
        public string dreNumber { get; set; }
        public string dreSeries { get; set; }
        public string modelType { get; set; }
        public string contractsCount { get; set; }

        public Announcement ToBaseObject()
        {
            return
                new Announcement()
                {
                    id = id,
                    type = StringHelper.ClearString(type),
                    basePrice = StringHelper.ClearFloat(basePrice),
                    contractDesignation = StringHelper.ClearString(contractDesignation),
                    drPublicationDate = StringHelper.ClearDate(drPublicationDate),
                    proposalDeadline = StringHelper.ClearDate(proposalDeadline),
                    contractingEntity = StringHelper.ClearString(contractingEntity),

                    reference = StringHelper.ClearString(reference),
                    announcementNumber = StringHelper.ClearString(announcementNumber),
                    contractType = StringHelper.ClearString(contractType),
                    contractingEntities = contractingEntities == null ? null : contractingEntities.Select(_ => new Entity() { id = _.id, description = _.description, nif = _.nif }).ToList(),
                    cpvs = StringHelper.ClearString(cpvs),
                    dreNumber = StringHelper.ClearString(dreNumber),
                    dreSeries = StringHelper.ClearString(dreSeries),
                    modelType = StringHelper.ClearString(modelType),
                    contractsCount = StringHelper.ClearInt(contractsCount),
                };
        }
    }
}
