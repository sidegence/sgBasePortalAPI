using System;
using System.Collections.Generic;
using System.Linq;

using sgBasePortalAPI.Helpers;

namespace sgBasePortalAPI
{
    public enum ContractSortColumn
    {
        id,
        type,
        basePrice,
        contractDesignation,
        drPublicationDate,
        proposalDeadline,
        contractingEntity,
    }

    public enum ContractFilterColumn
    {
        emissora,
        desdedatapublicacao,
        atedatapublicacao,
        desdeprecobase,
        ateprecobase,
    }

    [Serializable]
    public class Contract
    {
        public float totalEffectivePrice { get; set; }
        public DateTime? publicationDate { get; set; }
        public int announcementId { get; set; }
        public string frameworkAgreementProcedureId { get; set; }
        public string observations { get; set; }
        public string directAwardFundamentationType { get; set; }
        public List<Entity> invitees { get; set; }
        public List<Entity> contestants { get; set; }
        public string contractFundamentationType { get; set; }
        public string increments { get; set; }
        public DateTime? closeDate { get; set; }
        public string causesDeadlineChange { get; set; }
        public string causesPriceChange { get; set; }
        public string frameworkAgreementProcedureDescription { get; set; }
        public int id { get; set; }
        public string description { get; set; }
        public string contractingProcedureType { get; set; }
        public string executionDeadline { get; set; }
        public string contractTypes { get; set; }
        public string executionPlace { get; set; }
        public string cpvs { get; set; }
        public string objectBriefDescription { get; set; }
        public string centralizedProcedure { get; set; }
        public string contractStatus { get; set; }
        public float initialContractualPrice { get; set; }
        public DateTime? signingDate { get; set; }
        public List<Entity> contracted { get; set; }
        public List<Entity>contracting { get; set; }
        public string contractedForListedSearch { get; set; }
        public string contractingForListedSearch { get; set; }

        public string ToLongString()
        {
            return
                string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29}",
                    totalEffectivePrice,
                    publicationDate,
                    announcementId,
                    frameworkAgreementProcedureId,
                    observations,
                    directAwardFundamentationType,
                    invitees == null ? 0 : invitees.Count,
                    contestants == null ? 0 : contestants.Count,
                    contractFundamentationType,
                    increments,
                    closeDate,
                    causesDeadlineChange,
                    causesPriceChange,
                    frameworkAgreementProcedureDescription,
                    id,
                    description,
                    contractingProcedureType,
                    executionDeadline,
                    contractTypes,
                    executionPlace,
                    cpvs,
                    objectBriefDescription,
                    centralizedProcedure,
                    contractStatus,
                    initialContractualPrice,
                    signingDate,
                    contracted == null ? 0 : contracted.Count,
                    contracting == null ? 0 : contracting.Count,
                    contractedForListedSearch,
                    contractingForListedSearch
                );
        }
    }

    [Serializable]
    internal class ContractJson
    {
        public string totalEffectivePrice { get; set; }
        public string publicationDate { get; set; }
        public int announcementId { get; set; }
        public string frameworkAgreementProcedureId { get; set; }
        public string observations { get; set; }
        public string directAwardFundamentationType { get; set; }
        public List<Entity> invitees { get; set; }
        public List<Entity> contestants { get; set; }
        public string contractFundamentationType { get; set; }
        public string increments { get; set; }
        public string closeDate { get; set; }
        public string causesDeadlineChange { get; set; }
        public string causesPriceChange { get; set; }
        public string frameworkAgreementProcedureDescription { get; set; }
        public int id { get; set; }
        public string description { get; set; }
        public string contractingProcedureType { get; set; }
        public string executionDeadline { get; set; }
        public string contractTypes { get; set; }
        public string executionPlace { get; set; }
        public string cpvs { get; set; }
        public string objectBriefDescription { get; set; }
        public string centralizedProcedure { get; set; }
        public string contractStatus { get; set; }
        public string initialContractualPrice { get; set; }
        public string signingDate { get; set; }
        public List<Entity> contracted { get; set; }
        public List<Entity> contracting { get; set; }

        public Contract ToBaseObject()
        {
            return
                new Contract()
                {
                    totalEffectivePrice = StringHelper.ClearFloat(totalEffectivePrice),
                    publicationDate = StringHelper.ClearDate(publicationDate),
                    announcementId = announcementId,
                    frameworkAgreementProcedureId = StringHelper.ClearString(frameworkAgreementProcedureId),
                    observations = StringHelper.ClearString(observations),
                    directAwardFundamentationType = StringHelper.ClearString(directAwardFundamentationType),
                    invitees = invitees == null ? null : invitees.Select(_ => new Entity() { id = _.id, description = _.description, nif = _.nif }).ToList(),
                    contestants = contestants == null ? null : contestants.Select(_ => new Entity() { id = _.id, description = _.description, nif = _.nif }).ToList(),
                    contractFundamentationType = StringHelper.ClearString(contractFundamentationType),
                    increments = StringHelper.ClearString(increments),
                    closeDate = StringHelper.ClearDate(closeDate),
                    causesDeadlineChange = StringHelper.ClearString(causesDeadlineChange),
                    causesPriceChange = StringHelper.ClearString(causesPriceChange),
                    frameworkAgreementProcedureDescription = StringHelper.ClearString(frameworkAgreementProcedureDescription),
                    id = id,
                    description = StringHelper.ClearString(description),
                    contractingProcedureType = StringHelper.ClearString(contractingProcedureType),
                    executionDeadline = StringHelper.ClearString(executionDeadline),
                    contractTypes = StringHelper.ClearString(contractTypes),
                    executionPlace = StringHelper.ClearString(executionPlace),
                    cpvs = StringHelper.ClearString(cpvs),
                    objectBriefDescription = StringHelper.ClearString(objectBriefDescription),
                    centralizedProcedure = StringHelper.ClearString(centralizedProcedure),
                    contractStatus = StringHelper.ClearString(contractStatus),
                    initialContractualPrice = StringHelper.ClearFloat(initialContractualPrice),
                    signingDate = StringHelper.ClearDate(signingDate),
                    contracted = contracted == null ? null : contracted.Select(_ => new Entity() { id = _.id, description = _.description, nif = _.nif }).ToList(),
                    contracting = contracting == null ? null : contracting.Select(_ => new Entity() { id = _.id, description = _.description, nif = _.nif }).ToList()
                };
        }
    }

    [Serializable]
    internal class ContractJsonForListedSearch
    {
        public string publicationDate { get; set; }
        public int id { get; set; }
        public string objectBriefDescription { get; set; }
        public string initialContractualPrice { get; set; }
        public string contracted { get; set; }
        public string contracting { get; set; }

        public Contract ToBaseObject()
        {
            return
                new Contract()
                {
                    publicationDate = StringHelper.ClearDate(publicationDate),
                    id = id,
                    objectBriefDescription = StringHelper.ClearString(objectBriefDescription),
                    initialContractualPrice = StringHelper.ClearFloat(initialContractualPrice),
                    contractedForListedSearch = StringHelper.ClearString(contracted),
                    contractingForListedSearch = StringHelper.ClearString(contracting)
                };
        }
    }
}
