import * as Action from '../actionTypes';

import _ from 'lodash';

const DEFAULT_MODELS = {
  users: {
    data: {},
    loading: false,
    loaded: false,
  },
  user: {},
  userDistricts: {
    data: {},
    loading: false,
  },
  currentUserDistricts: {
    data: {},
    loading: false,
  },

  favourites: {
    equipment: {},
    hiringReport: {},
    owner: {},
    ownersCoverage: {},
    project: {},
    rentalRequests: {},
    timeEntry: {},
    user: {},
  },

  equipmentList: {
    data: {},
    loading: false,
    loaded: false,
  },
  equipment: {},
  equipmentSeniorityHistory: {},
  equipmentNotes: {},
  equipmentAttachments: {},
  equipmentHistory: {},
  equipmentRentalAgreements: {
    data: {},
  },
  equipmentTransfer: {},

  owners: {
    data: {},
    loading: false,
    loaded: false,
  },
  ownersLite: {
    data: {},
    loading: false,
    loaded: false,
  },
  owner: {},
  ownerEquipment: {
    data: {},
    loading: false,
    loaded: false,
  },
  ownerNotes: {},
  ownerAttachments: {},
  ownerHistory: {},

  projects: {
    data: {},
    loading: false,
    loaded: false,
  },
  project: {},
  // projectEquipment: {
  //   data: {},
  //   loading: false,
  //   success: false,
  // },
  // projectTimeRecords: {
  //   data: {},
  //   loading: false,
  //   success: false,
  // },
  projectNotes: {},
  projectAttachments: {},
  projectHistory: {},
  projectRentalAgreements: {
    data: {},
  },

  rentalRequests: {
    data: {},
    loading: false,
    loaded: false,
  },
  rentalRequest: {
    data: {},
    loading: false,
    success: false,
    error: false,
    errorMessage: '',
  },
  rentalRequestNotes: {},
  rentalRequestAttachments: {},
  rentalRequestHistory: {},
  rentalRequestRotationList: {
    data: {},
    loading: false,
    success: false,
  },

  rentalAgreement: {},
  rentalAgreementNotes: {},
  rentalAgreementHistory: {},
  rentalAgreementTimeRecords: {},
  rentalRate: {},
  rentalCondition: {},
  rentalConditions: {},

  timeEntries: {
    data: {},
    loading: false,
    loaded: false,
  },

  hiringResponses: {
    data: {},
    loading: false,
    loaded: false,
  },

  ownersCoverage: {
    data: {},
    loading: false,
    loaded: false,
  },

  roles: {},
  role: {},
  rolePermissions: {},

  // XXX: Looks like this is unused
  // contacts: {},
  // contact: {},

  documents: {},
  document: {},

  history: {},

  timeRecord: {
    data: {},
  },

  business: {},

  batchReports: [],
};

export default function modelsReducer(state = DEFAULT_MODELS, action) {
  switch(action.type) {
    // Users
    case Action.USERS_REQUEST:
      return { ...state, users: { ...state.users, loading: true, loaded: false } };

    case Action.UPDATE_USERS:
      return { ...state, users: { data: action.users, loading: false, loaded: true } };

    case Action.CLEAR_USERS:
      return { ...state, users: { data: {}, loading: false, loaded: false } };

    case Action.UPDATE_USER:
      return { ...state, user: action.user };

    case Action.ADD_USER:
      return { ...state, user: action.user };

    case Action.DELETE_USER:
      return { ...state, user: action.user };

    case Action.USER_DISTRICTS:
      return { ...state, userDistricts: { data: action.userDistricts, loading: false } };

    case Action.CURRENT_USER_DISTRICTS:
      return { ...state, currentUserDistricts: { data: action.currentUserDistricts, loading: false } };

    // Favourites
    case Action.UPDATE_FAVOURITES:
      return { ...state, favourites: { ...state.favourites, ...action.favourites } };

    case Action.ADD_FAVOURITE: case Action.UPDATE_FAVOURITE:
      return { ...state, favourites: { ...state.favourites, [action.favourite.type]: { ...state.favourites[action.favourite.type], [action.favourite.id]: action.favourite } } };

    case Action.DELETE_FAVOURITE:
      return { ...state, favourites: { ...state.favourites, [action.favourite.type]: _.omit(state.favourites[action.favourite.type], [ action.favourite.id ]) } };

    // Contacts
    // XXX: Looks like this is unused
    // case Action.ADD_CONTACT:
    //   return { ...state, contact: action.contact };

    // XXX: Looks like this is unused
    // case Action.UPDATE_CONTACT:
    //   return { ...state, contact: action.contact };

    // XXX: Looks like this is unused
    // case Action.DELETE_CONTACT:
    //   return { ...state, contact: action.contact };

    // Documents
    case Action.UPDATE_DOCUMENTS:
      return { ...state, documents: action.documents };

    case Action.ADD_DOCUMENT:
      return { ...state, document: action.document };

    case Action.UPDATE_DOCUMENT:
      return { ...state, document: action.document };

    case Action.DELETE_DOCUMENT:
      return { ...state, document: action.document };

    // Equipment
    case Action.EQUIPMENT_LIST_REQUEST:
      return { ...state, equipmentList: { ...state.equipmentList, loading: true, loaded: false } };

    case Action.UPDATE_EQUIPMENT_LIST:
      return { ...state, equipmentList: { data: action.equipmentList, loading: false, loaded: true } };

    case Action.CLEAR_EQUIPMENT_LIST:
      return { ...state, equipmentList: { data: {}, loading: false, loaded: false } };

    case Action.ADD_EQUIPMENT: case Action.UPDATE_EQUIPMENT:
      return { ...state, equipment: action.equipment };

    case Action.UPDATE_EQUIPMENT_NOTES:
      return { ...state, equipmentNotes: action.notes };

    case Action.UPDATE_EQUIPMENT_RENTAL_AGREEMENTS:
      return { ...state, equipmentRentalAgreements: { data: action.rentalAgreements } };

    case Action.EQUIPMENT_TRANSFER_ERROR:
      return { ...state, equipmentTransfer: { ...state.equipmentTransfer, error: true, errorMessage: action.errorMessage } };

    // Owners
    case Action.OWNERS_REQUEST:
      return { ...state, owners: { ...state.owners, loading: true, loaded: false } };

    case Action.UPDATE_OWNERS:
      return { ...state, owners: { data: action.owners, loading: false, loaded: true } };

    case Action.OWNERS_LITE_REQUEST:
      return { ...state, ownersLite: { ...state.ownersLite, loading: true, loaded: false } };

    case Action.OWNER_EQUIPMENT_REQUEST:
      return { ...state, ownerEquipment: { data: action.equipment, loading: true, loaded: false } };

    case Action.UPDATE_OWNER_EQUIPMENT:
      return { ...state, ownerEquipment: { data: action.equipment, loading: false, loaded: true } };

    case Action.UPDATE_OWNERS_LITE:
      return { ...state, ownersLite: { data: action.owners, loading: false, loaded: true } };

    case Action.CLEAR_OWNERS:
      return { ...state, owners: { data: {}, loading: false, loaded: false } };

    // XXX: Looks like `Action.DELETE_OWNER` is unused
    case Action.ADD_OWNER: case Action.UPDATE_OWNER:/*  case Action.DELETE_OWNER: */
      return { ...state, owner: action.owner };

    case Action.UPDATE_OWNER_NOTES:
      return { ...state, ownerNotes: action.notes };

    // Projects
    case Action.PROJECTS_REQUEST:
      return { ...state, projects: { ...state.projects, loading: true, loaded: false } };

    case Action.UPDATE_PROJECTS:
      return { ...state, projects: { data: action.projects, loading: false, loaded: true } };

    case Action.CLEAR_PROJECTS:
      return { ...state, projects: { data: {}, loading: false, loaded: false } };

    case Action.ADD_PROJECT: case Action.UPDATE_PROJECT:
      return { ...state, project: action.project };

    // case Action.UPDATE_PROJECT_EQUIPMENT:
    //   return { ...state, projectEquipment: { data: action.projectEquipment, loading: false, success: true } };

    // XXX: Looks like this is unused
    // case Action.UPDATE_PROJECT_TIME_RECORDS:
    //   return { ...state, projectTimeRecords: { data: action.projectTimeRecords, loading: false, success: true } };

    case Action.UPDATE_PROJECT_NOTES:
      return { ...state, projectNotes: action.notes };

    case Action.UPDATE_PROJECT_RENTAL_AGREEMENTS:
      return { ...state, projectRentalAgreements: { data: action.rentalAgreements } };

    case Action.DELETE_PROJECT_RENTAL_REQUEST: {
      const updatedList = state.project.rentalRequests.filter((rentalRequest) => rentalRequest.id !== action.requestId);
      return { ...state, project: { ...state.project, rentalRequests: updatedList } };
    }

    // XXX: Looks like this is unused
    // case Action.UPDATE_PROJECT_RENTAL_AGREEMENTS_ERROR:
    //   return { ...state, projectRentalAgreements: { ...state.projectRentalAgreements, error: action.error } };

    // Rental Requests
    case Action.RENTAL_REQUESTS_REQUEST:
      return { ...state, rentalRequests: { ...state.rentalRequests, loading: true, loaded: false } };

    case Action.UPDATE_RENTAL_REQUESTS:
      return { ...state, rentalRequests: { data: action.rentalRequests, loading: false, loaded: true } };

    case Action.CLEAR_RENTAL_REQUESTS:
      return { ...state, rentalRequests: { data: {}, loading: false, loaded: false } };

    case Action.RENTAL_REQUEST_REQUEST:
      return { ...state, rentalRequest: { ...state.rentalRequest, loading: true, success: false, error: false, errorMessage: '' } };

    case Action.ADD_RENTAL_REQUEST:
    case Action.UPDATE_RENTAL_REQUEST:
      return { ...state, rentalRequest: { data: action.rentalRequest, loading: false, success: true } };

    case Action.ADD_RENTAL_REQUEST_ERROR:
      return { ...state, rentalRequest: { ...state.rentalRequest, error: true, errorMessage: action.errorMessage } };

    case Action.ADD_RENTAL_REQUEST_REFRESH:
      return { ...state, rentalRequest: { ...DEFAULT_MODELS.rentalRequest } };

    case Action.UPDATE_RENTAL_REQUEST_NOTES:
      return { ...state, rentalRequestNotes: action.notes };

    // Time Entries
    case Action.TIME_ENTRIES_REQUEST:
      return { ...state, timeEntries: { ...state.timeEntries, loading: true, loaded: false } };

    case Action.UPDATE_TIME_ENTRIES:
      return { ...state, timeEntries: { data: action.timeEntries, loading: false, loaded: true } };

    case Action.CLEAR_TIME_ENTRIES:
      return { ...state, timeEntries: { data: {}, loading: false, loaded: false } };

    // Hiring Responses
    case Action.HIRING_RESPONSES_REQUEST:
      return { ...state, hiringResponses: { ...state.hiringResponses, loading: true, loaded: false } };

    case Action.UPDATE_HIRING_RESPONSES:
      return { ...state, hiringResponses: { data: action.hiringResponses, loading: false, loaded: true } };

    case Action.CLEAR_HIRING_RESPONSES:
      return { ...state, hiringResponses: { data: {}, loading: false, loaded: false } };

    // Owners' Coverage
    case Action.OWNERS_COVERAGE_REQUEST:
      return { ...state, ownersCoverage: { ...state.ownersCoverage, loading: true, loaded: false } };

    case Action.UPDATE_OWNERS_COVERAGE:
      return { ...state, ownersCoverage: { data: action.ownersCoverage, loading: false, loaded: true } };

    case Action.CLEAR_OWNERS_COVERAGE:
      return { ...state, ownersCoverage: { data: {}, loading: false, loaded: false } };

    // Rotation List
    case Action.RENTAL_REQUEST_ROTATION_LIST_REQUEST:
      return { ...state, rentalRequestRotationList: { ...state.rentalRequestRotationList, loading: true, success: false } };

    case Action.UPDATE_RENTAL_REQUEST_ROTATION_LIST:
      return { ...state, rentalRequestRotationList: { data: action.rentalRequestRotationList, loading: false, success: true } };

    // Rental Agreements
    // XXX: Looks like this is unused
    // case Action.ADD_RENTAL_AGREEMENT:
    //   return { ...state, rentalAgreement: { ...state.rentalAgreement, [action.rentalAgreement.id]: action.rentalAgreement } };

    case Action.GENERATE_ANOTHER_RENTAL_AGREEMENT:
      return { ...state, rentalAgreement: { ...state.rentalAgreement, [action.rentalAgreement.id]: action.rentalAgreement } };

    case Action.UPDATE_RENTAL_AGREEMENT:
      return { ...state, rentalAgreement: { ...state.rentalAgreement, [action.rentalAgreement.id]: action.rentalAgreement } };

    case Action.RENTAL_AGREEMENT_TIME_RECORDS:
      return { ...state, rentalAgreementTimeRecords: action.rentalAgreementTimeRecords };

    // Rental Rates, Conditions
    case Action.ADD_RENTAL_RATE:
      return { ...state, rentalRate: action.rentalRate };

    case Action.UPDATE_RENTAL_RATE:
      return { ...state, rentalRate: action.rentalRate };

    case Action.DELETE_RENTAL_RATE:
      return { ...state, rentalRate: action.rentalRate };

    case Action.ADD_RENTAL_CONDITION:
      return { ...state, rentalCondition: action.rentalCondition };

    case Action.UPDATE_RENTAL_CONDITION:
      return { ...state, rentalCondition: action.rentalCondition };

    case Action.DELETE_RENTAL_CONDITION:
      return { ...state, rentalCondition: action.rentalCondition };

    case Action.UPDATE_RENTAL_CONDITIONS:
      return { ...state, rentalConditions: action.rentalConditions };

    // Roles, Permissions
    case Action.UPDATE_ROLES:
      return { ...state, roles: action.roles };

    case Action.ADD_ROLE:
      return { ...state, role: action.role };

    case Action.UPDATE_ROLE:
      return { ...state, role: action.role };

    case Action.DELETE_ROLE:
      return { ...state, role: action.role };

    case Action.UPDATE_ROLE_PERMISSIONS:
      return { ...state, rolePermissions: action.rolePermissions };

    // History
    case Action.UPDATE_HISTORY:
      return { ...state, history: action.history };

    // Notes
    case Action.DELETE_NOTE: {
      let notesCollectionName = null;

      if (action.noteId in state.projectNotes) {
        notesCollectionName = 'projectNotes';
      } else if (action.noteId in state.equipmentNotes) {
        notesCollectionName = 'equipmentNotes';
      } else if (action.noteId in state.ownerNotes) {
        notesCollectionName = 'ownerNotes';
      } else if (action.noteId in state.rentalRequestNotes) {
        notesCollectionName = 'rentalRequestNotes';
      }

      if (notesCollectionName) {
        const notes = state[notesCollectionName];
        const updatedNotes = _.fromPairs(Object.keys(notes).filter((noteId) => {
          return noteId !== String(action.noteId);
        }).map((id) => [ id, notes[id] ]));

        return { ...state, [notesCollectionName]: updatedNotes };
      }

      return state;
    }

    // Time Record
    case Action.DELETE_TIME_RECORD:
      return { ...state, timeRecord: { data: action.timeRecord } };

    // Businesses
    case Action.UPDATE_BUSINESS:
      return { ...state, business: action.business };

    // Batch Reports
    case Action.UPDATE_BATCH_REPORTS:
      return { ...state, batchReports: action.batchReports };

    case Action.DELETE_BATCH_REPORT: {
      const filteredBatchReports = state.batchReports.filter((br) => br.id !== action.batchReportId);
      return { ...state, batchReports: filteredBatchReports };}
  }
  return state;
}

export const modelsSelector = (state) => state.models;
